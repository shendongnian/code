      public static Bitmap Capture()
        {
            Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.CopyFromScreen( 100, 100, 100, 100, bitmap.Size);
            }
            return bitmap;
        }
