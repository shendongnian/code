        private Bitmap GenerateSurface(Image imgParent, List<Image> surfImgs, ToothSurfaceMaterial material)
        {
            Bitmap mask = new Bitmap(imgParent.Width, imgParent.Height,
                           System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            using (Graphics g = Graphics.FromImage(mask))
            {
                foreach (Image img in surfImgs)
                {
                    g.DrawImage(img, System.Drawing.Point.Empty);
                }
            }
            Bitmap output = new Bitmap(mask.Width, mask.Height,
                           System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            using (Graphics g = Graphics.FromImage(output))
            {
                if (material.HatchStyle != null)
                {
                    HatchBrush hb = new HatchBrush((HatchStyle)material.HatchStyle, material.FgColor, material.BgColor);
                    g.FillRectangle(hb, new Rectangle(0, 0, output.Width, output.Height));
                }
                else
                {
                    SolidBrush sb = new SolidBrush(material.FgColor);
                    g.FillRectangle(sb, new Rectangle(0, 0, output.Width, output.Height));
                }
            }
            var rect = new Rectangle(0, 0, output.Width, output.Height);
            var bitsMask = mask.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            var bitsOutput = output.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            unsafe
            {
                int offset = 0;
                for (int y = 0; y < mask.Height; y++)
                {
                    byte* ptrMask = (byte*)bitsMask.Scan0 + y * bitsMask.Stride;
                    byte* ptrOutput = (byte*)bitsOutput.Scan0 + y * bitsOutput.Stride;
                    for (int x = 0; x < mask.Width; x++)
                    {
                        offset = 4 * x + 3;
                        ptrOutput[offset] = (byte)(ptrMask[offset] * 0.7);
                    }
                }
            }
            mask.UnlockBits(bitsMask);
            output.UnlockBits(bitsOutput);
            return output;
        }
