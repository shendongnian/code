      private void pictureBox1_Click(object sender, EventArgs e)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                string path1 = path.Replace(@"\bin\Debug\", @"\Pics\");
    
               if (kast1 == 1)
               {
                   this.pictureBox_terning1.Image = new Bitmap(path1 + "terning1.png"); 
               }
               //rest of the code
            }
