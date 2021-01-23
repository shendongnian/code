      private void Form1_Load(object sender, EventArgs e)
        {
            int x = 10, y = 10;
            string[] file = System.IO.Directory.GetFiles(@"C:\Users\Public\Pictures\Sample Pictures\",             "*.jpg");
            PictureBox[] pb = new PictureBox[file.Length];
            for (int i = 0; i < file.Length; i++)
            {
                pb[i] = new PictureBox();
                pb[i].Size = new System.Drawing.Size(100,100);
                pb[i].ImageLocation = file[i];
                pb[i].Location = new Point(x, y);
                this.Controls.Add(pb[i]);
                x += 100;
                if (i == 5)
                {
                     x = 10;
                     y += 120;
                }
            }
        }
