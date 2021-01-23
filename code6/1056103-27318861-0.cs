    using System;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using Microsoft.WindowsAPICodePack.Shell;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                string fileName = @"\\PC\Users\Public\bitmap.bmp";
                ShellFile shellFile = ShellFile.FromFilePath(fileName);
                ShellThumbnail thumbnail = shellFile.Thumbnail;
                var pictureBox = new PictureBox
                {
                    Image = thumbnail.Bitmap,
                    Dock = DockStyle.Fill
                };
                Controls.Add(pictureBox);
            }
        }
    }
