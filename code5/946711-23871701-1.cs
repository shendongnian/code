    class PixelColor
    {
        [DllImport("gdi32")]
        public static extern uint GetPixel(IntPtr hDC, int XPos, int YPos);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);
        /// <summary> 
        /// Gets the System.Drawing.Color from under the given position. 
        /// </summary> 
        /// <returns>The color value.</returns> 
        public static Color Get(int x, int y)
        {
            IntPtr dc = GetWindowDC(IntPtr.Zero);
            long color = GetPixel(dc, x, y);
            Color cc = Color.FromArgb((int)color);
            return Color.FromArgb(cc.B, cc.G, cc.R);
        }
    }
