        private void ApplyColor(Bitmap bm, Color userColor)
        {
            if (bm==null)
                return;
			// pixels loop	
            for (int i = 0; i < bm.Width; i++)
            {
                for (int j = 0; j < bm.Height; j++)
                {
					// get current pixel
                    Color curPix = bm.GetPixel(i, j);
                    Color curPixColor = Color.FromArgb(curPix.A, curPix.R, curPix.G, curPix.B);
					
					// get result color by blending 
                    Color resultColor = Blend(curPixColor, userColor, ColorMixFactor);
                    //  set pixel color
                    bm.SetPixel(i, j, resultColor);
                }
            }
        }
		
		public static Color Blend(Color srcColor, Color dstColor, double amount)
        {
			// restrict black (dark) color from being affected by the blending
            var br = srcColor.GetBrightness();
            if (br < BrightnessToAvoid)
                return srcColor;
			// get all 4 color channels 
            var r = (byte) ((srcColor.R*amount) + dstColor.R*(1 - amount));
            var g = (byte) ((srcColor.G*amount) + dstColor.G*(1 - amount));
            var b = (byte) ((srcColor.B*amount) + dstColor.B*(1 - amount));
            var a = srcColor.A;
			// get blended color
            return Color.FromArgb(a, r, g, b);
        }
