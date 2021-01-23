            var rc = SystemInformation.VirtualScreen;
            using (Bitmap bmp = new Bitmap(rc.Width, rc.Height, PixelFormat.Format32bppRgb))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(rc.Left, rc.Top, 0, 0, bmp.Size);
                }
                using (var snipper = new SnippingTool(bmp))
                {
                    if (snipper.ShowDialog() == DialogResult.OK)
                    {
                        return snipper.Image;
                    }
                }
                return null;
            }
