    void takeScreenshot()
        {
            Application.DoEvents();
            System.Drawing.Rectangle bounds = Mainpanel.Bounds;
            bounds.Width = bounds.Width - 6;
            bounds.Height = bounds.Height - 4;
            using (Bitmap bitmap = new Bitmap(Mainpanel.Width, Mainpanel.Height))
            {
                Mainpanel.DrawToBitmap(bitmap, new Rectangle(3, 2, bounds.Width, bounds.Height));
                bitmap.Save(Application.StartupPath + "\\data\\programdata\\temppic.bmp");
            }
        }
