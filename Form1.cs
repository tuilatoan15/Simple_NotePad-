using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Simple_NotePad
{
    public partial class Form1 : Form
    {
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;

        public Form1()
        {
            InitializeComponent();
        }

        void NewTab()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.richTextBox1.Text))
                {
                    if (MessageBox.Show("Bạn có muốn lưu File đang mở?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        SaveFile();
                        this.richTextBox1.Text = string.Empty;
                        this.Text = "Simple NotePad";
                    }
                    else
                    {
                        this.richTextBox1.Text = string.Empty;
                        this.Text = "Simple NotePad";
                    }
                } 
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

        void OpenFile()
        {
            try
            {
                if (this.Text == "Simple NotePad" && !(string.IsNullOrEmpty(this.richTextBox1.Text)))
                {
                    if (MessageBox.Show("Bạn có muốn lưu File đang mở?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        SaveFile();
                    }
                    else
                    {
                        openFileDialog = new OpenFileDialog();
                        openFileDialog.Title = "Vui lòng chọn File để mở!";
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            this.richTextBox1.Text = File.ReadAllText(openFileDialog.FileName);
                            this.Text = openFileDialog.FileName;
                        }
                    }
                    return;
                }

                openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Vui lòng chọn File để mở!";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.richTextBox1.Text = File.ReadAllText(openFileDialog.FileName);
                    this.Text = openFileDialog.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở File!", "Lỗi");
            }
            finally
            {

            }
        }

        void SaveFile()
        {
            try
            {
                saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text File (*.txt) | *.txt";
                saveFileDialog.Title = "Hãy chọn nơi để lưu và Nhập tên File!";
                
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, this.richTextBox1.Text);
                    this.Text = saveFileDialog.FileName;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

        void SaveAsFile()
        {
            try
            {
                saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text File (*.txt) | *.txt | All File (*.*) | *.*";
                saveFileDialog.Title = "Hãy chọn nơi để lưu và Nhập tên File!";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, this.richTextBox1.Text);
                    this.Text = saveFileDialog.FileName;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

        private void newTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewTab();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAsFile();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.richTextBox1.Text) && (this.Text == "Simple NotePad"))
                {
                    if (MessageBox.Show("Bạn có muốn lưu File đang mở?", "Thông báo") == DialogResult.OK)
                    {
                        SaveFile();
                    }
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

        private void youtubeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = @"https://www.youtube.com/@ToanNguyen-ew6nf";
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi mở liên kết!", "Lỗi");
            }
        }

        private void githubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string url = @"https://github.com/tuilatoan15";
                Process.Start(new ProcessStartInfo {
                    FileName = url,
                    UseShellExecute = true
                });

            }
            catch (Exception ex)
            {

            }
        }
    }
}
