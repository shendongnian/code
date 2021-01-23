            try
            {
                this.Close();
                System.Drawing.Rectangle bounds = Mainpanel.Bounds;
                bounds.Width = bounds.Width - 6;
                bounds.Height = bounds.Height - 4;
                using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(Mainpanel.PointToScreen(new Point()).X + 3, Mainpanel.PointToScreen(new Point()).Y + 2, 0, 0, bounds.Size);
                    }
...
