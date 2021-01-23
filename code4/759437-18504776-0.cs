    private void button3_Click(object sender, EventArgs e)
    {
        Rectangle form = this.Bounds;
        using (Bitmap bitmap = new Bitmap(form.Width, form.Height))
        {
            using (Graphics graphic =
                Graphics.FromImage(bitmap))
            {
                graphic.CopyFromScreen(form.Location,
                    Point.Empty, form.Size);
            }
            int count = 1;
  
            string baseFileName = "OpenVMK";
            string ext = ".jpg";
            string pathToFile = "C:/Users/G73/Desktop/My OVMK Photos";            
            while(System.IO.File.Exists(System.IO.Path.Combine(pathToFile, string.Format("{0}{1}{2}", baseFileName, i++, ext))) {};
            bitmap.Save(System.IO.Path.Combine(pathToFile, string.Format("{0}{1}{2}", baseFileName, i++, ext)), ImageFormat.Jpeg);
        }
    }
