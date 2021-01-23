    foreach (string file in files )
    {
        System.IO.FileInfo fileInfo = new System.IO.FileInfo(file);
        System.IO.FileStream fileStream = fileInfo.OpenRead();
        pictureBox1.Image = System.Drawing.Image.FromStream(fileStream);
        Application.DoEvents();
        fileStream.Close();
        // Call Sleep so the picture is briefly displayed,  
        //which will create a slide-show effect.
        System.Threading.Thread.Sleep(2000);
    }
