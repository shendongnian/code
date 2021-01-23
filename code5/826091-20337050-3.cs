        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Set the starting coordinants for our graphics drawing
            int y = 0;
            int x = 0;
            // Set the end coordinants for our graphics drawing
            int width = this.Size.Width;
            int height = this.Size.Height;
            // Set our graphics options
            e.Graphics.InterpolationMode = XGraphics.xInterpolation;
            e.Graphics.SmoothingMode = XGraphics.xSmoothingMode;
            e.Graphics.CompositingMode = XGraphics.xComposingMode;
            e.Graphics.CompositingQuality = XGraphics.xComposingQuality;
            e.Graphics.PixelOffsetMode = XGraphics.xPixelOffsetMode;
            // Set the colors, positions, and gradient directions then draw our background
            using (LinearGradientBrush gpxBrush = XGraphics.GradientBrushOrientation(0, x, y, width, height))
            {
                // Create our color blender object
                ColorBlend gpxBlend = null;
                gpxBlend = new ColorBlend(4);
                gpxBlend.Colors = new Color[] { Color.FromArgb(255, 0, 100, 255), Color.FromArgb(205, 255, 240, 240),
                Color.FromArgb(255, 20, 100, 230), Color.FromArgb(105, 105, 100, 255)  };
                gpxBlend.Positions = new float[] { 0.0F, .45F, .55F, 1.0F };
                gpxBrush.InterpolationColors = gpxBlend;
                // Draw our background
                e.Graphics.FillEllipse(gpxBrush, x, y, width, height);
            }
            // Set the end coordinants for our graphics drawing
            width = this.Size.Width-5;
            height = this.Size.Height-5;
            using (LinearGradientBrush gpxBrush = XGraphics.GradientBrushOrientation(0, x, y, width, height))
            {
                // Create our color blender object
                ColorBlend gpxBlend = null;
                gpxBlend = new ColorBlend(2);
                gpxBlend.Colors = new Color[] { Color.White, Color.Gray };
                gpxBlend.Positions = new float[] { 0.0F, 1.0F };
                gpxBrush.InterpolationColors = gpxBlend;
                // Draw our background
                e.Graphics.FillEllipse(gpxBrush, x+5, y+5, width-5, height-5);
            }
            
            width = this.Size.Width / 2;
            height = this.Size.Height / 2;
            using (LinearGradientBrush gpxBrush = XGraphics.GradientBrushOrientation(0, x, y, width, height))
            {
                // Create our color blender object
                ColorBlend gpxBlend = null;
                gpxBlend = new ColorBlend(2);
                gpxBlend.Colors = new Color[] { Color.White, Color.Gray };
                gpxBlend.Positions = new float[] { 0.0F, 1.0F };
                gpxBrush.InterpolationColors = gpxBlend;
                // Draw our background
                e.Graphics.FillEllipse(gpxBrush, x + width / 2, y + height / 2, width, height);
            }
            width = (this.Size.Width / 2) - 5;
            height = (this.Size.Height / 2) - 5;
            using (LinearGradientBrush gpxBrush = XGraphics.GradientBrushOrientation(0, x, y, width-5, height-5))
            {
                // Create our color blender object
                ColorBlend gpxBlend = null;
                gpxBlend = new ColorBlend(4);
                gpxBlend.Colors = new Color[] { Color.FromArgb(255, 0, 100, 255), Color.FromArgb(205, 255, 240, 240),
                Color.FromArgb(255, 20, 100, 230), Color.FromArgb(105, 105, 100, 255)  };
                gpxBlend.Positions = new float[] { 0.0F, .45F, .55F, 1.0F };
                gpxBrush.InterpolationColors = gpxBlend;
                // Draw our background
                e.Graphics.FillEllipse(gpxBrush, (x + width / 2)  +7, (y + height / 2) + 7, width - 5, height - 5);
            }
        }
