    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using System.Collections;
    
    
    namespace bitplane
    {
        public partial class Form1 : Form
        {
            public byte[] x;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                try
                {
                    if (o.ShowDialog() == DialogResult.OK)
                    {
                        OpenImage(o.FileName);
                        SaveImage(ConvertByteArrayToImage(x), @"C:\Users\Public\Pictures\Sample Pictures\New folder\fgh.jpg");
                    }
                }
                catch 
                {
                    MessageBox.Show("error");
                }
            }
    
            public void OpenImage(string path)
            {
                x = File.ReadAllBytes(path);
            }
    
            public void SaveImage(Image image, string path)
            {
                image.Save(path);
            }
    
            public Image ConvertByteArrayToImage(byte[] bytes)
            {
                System.IO.MemoryStream stream = new System.IO.MemoryStream(bytes);
                return Image.FromStream(stream);
            }
    }
