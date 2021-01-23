     private void Form1_Load(object sender, EventArgs e)
        {
            string szTarget = "C:\\someImage.gif";
            PictureBox pic = new PictureBox();
            pic.Dock = DockStyle.Fill;
            Image img = Image.FromFile(szTarget);   // Load image fromFile into Image object
            
            MemoryStream mstr = new MemoryStream(); // Create a new MemoryStream
            img.Save(mstr, ImageFormat.Gif);        // Save Image to MemoryStream from Image object
            
            pic.Image = Image.FromStream(mstr); // Load Image from MemoryStream into PictureBox
            this.Controls.Add(pic); 
            img.Dispose(); // Dispose original Image object (fromFile)
            // after this you should be able to delete/manipulate the file
            File.Delete(szTarget);
        }
