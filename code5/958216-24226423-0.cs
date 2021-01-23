    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    private void Form1_Load(object sender, EventArgs e)
        {
            var left = pictureBox1.Left;
            var top = pictureBox1.Top;
            var width = pictureBox1.Width;
            var height = pictureBox1.Height;
            var form = this;
            var currPictureBox = pictureBox1;
            new Thread(new ThreadStart(() =>
                {
                    for (var x = 1; x < 3; x++)
                    {
                        ExecuteSecure(() =>
                        {
                            var pictureBox = new PictureBox
                            {
                                Width = width,
                                Height = height,
                                Top = top,
                                Left = left,
                                ImageLocation = @"C:\filelocation" + x + ".jpg"
                            };
                            form.Controls.Remove(currPictureBox);
                            form.Controls.Add(pictureBox);
                            currPictureBox = pictureBox;
                            form.Refresh();
                        });
                        Thread.Sleep(1000);
                    }
                })).Start();
        }
        private void ExecuteSecure(Action a)
        {
            if (InvokeRequired)  BeginInvoke(a);
            else a();
        }
