    public class ColorMapper {
    
        private static Dictionary<int, String> colorMap = new Dictionary<Integer, String>()
        {
            {0xFFB6C1, "Light Pink"},
            {0x6B8E23, "Olive Drab"},
            //and the list goes on
        }
    
        public static String GetName(Color color)
        {
            //mask out the alpha channel
            int myRgb = color.ToArgb() & 0x00FFFFFFFF;
            if (colorMap.ContainsKey(myRgb))
            {
                return colorMap[myRgb];
            }
            return null;//or String.Empty if you prefer
        }
    }
