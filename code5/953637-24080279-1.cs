    public class RandomColorGenerator
    {
        private static List<int> addedIndex = new List<int>();
        public Color randomBrush { get { return generateRandomColor(); } }
        private static Random randomColor = new Random();
        private static uint[] uintColors =
        { 
            0xFF34AADC,0xFFFF2D55,0xFF007AFF,0xFFFF9500,0xFF4CD964,
            0xFFFFCC00,0xFF5856D6,0xFFFF3B30,0xFFFF4981,0xFFFF3A2D
        };
        private static Color ConvertColor(uint uintCol)
        {
            byte A = (byte)((uintCol & 0xFF000000) >> 24);
            byte R = (byte)((uintCol & 0x00FF0000) >> 16);
            byte G = (byte)((uintCol & 0x0000FF00) >> 8);
            byte B = (byte)((uintCol & 0x000000FF) >> 0);
            return Color.FromArgb(A, R, G, B); ;
        }
        public static Color generateRandomColor()
        {
            int random = randomColor.Next(0, 9);
            if (addedIndex.Count < 9)
            {
                while (addedIndex.Contains(random))
                {
                    random = randomColor.Next(0, 9);
                }
                addedIndex.Add(random);
            }
            return ConvertColor(uintColors[random]);
        }
    }
