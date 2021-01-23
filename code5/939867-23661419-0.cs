        private Color GetColorFromString(string colorHex)
        {
            var a = Convert.ToByte(colorHex.Substring(1, 2),16);
            var r = Convert.ToByte(colorHex.Substring(3, 2),16);
            var g = Convert.ToByte(colorHex.Substring(5, 2),16);
            var b = Convert.ToByte(colorHex.Substring(7, 2),16);
            return Color.FromArgb(a, r, g, b);
        }
