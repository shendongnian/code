    PropertyInfo imageRectangleProperty = typeof(PictureBox).GetProperty("ImageRectangle", BindingFlags.GetProperty | BindingFlags.NonPublic | BindingFlags.Instance);
    private void pictureBox1_Click(object sender, EventArgs e)
    {
        if (pictureBox1.Image != null)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Bitmap original = (Bitmap)pictureBox1.Image;
            Color? color = null;
            switch (pictureBox1.SizeMode)
            {
                case PictureBoxSizeMode.Normal:
                case PictureBoxSizeMode.AutoSize:
                    {
                        color = original.GetPixel(me.X, me.Y);
                        break;
                    }
                case PictureBoxSizeMode.CenterImage:
                case PictureBoxSizeMode.StretchImage:
                case PictureBoxSizeMode.Zoom:
                    {
                        Rectangle rectangle = (Rectangle)imageRectangleProperty.GetValue(pictureBox1, null);
                        using (Bitmap copy = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height))
                        {
                            using (Graphics g = Graphics.FromImage(copy))
                            {
                                g.DrawImage(pictureBox1.Image, rectangle);
                                if (rectangle.Contains(me.Location))
                                {
                                    color = copy.GetPixel(me.X, me.Y);
                                }
                            }
                        }
                        break;
                    }
            }
            if (!color.HasValue)
            {
                //User clicked somewhere there is no image
            }
            else
            { 
                //use color.Value
            }
        }
    }
