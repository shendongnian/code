    public static void SaveImageCapture(System.Drawing.Image image)
    {
        SaveFileDialog s = new SaveFileDialog();
        s.FileName = "Image";// Default file name
        s.DefaultExt = ".Jpg";// Default file extension
        s.Filter = "Image (.jpg)|*.jpg"; // Filter files by extension
        
        // Below are two examples of setting the initial (default) folder - choose one
        // 1. example of setting the default folder to a special folder
        s.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        
        // 2 example of setting the default folder to an absolute path
        //s.InitialDirectory = ("C:\\Temp");
        // setting the RestoreDirectory property to true causes the
        // dialog to restore the current directory before closing
        s.RestoreDirectory = true;
        // Show save file dialog box
        // Process save file dialog box results
        if (s.ShowDialog() == DialogResult.OK)
        {
            // Save Image
            string filename = s.FileName;
            // the using statement causes the FileStream's dispose method to be
            // called when the object goes out of scope
            using (System.IO.FileStream fstream = new System.IO.FileStream(filename, System.IO.FileMode.Create))
            {
                image.Save(fstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                fstream.Close();
            }
        }
    }
