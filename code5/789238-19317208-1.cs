    public static class StringExt
    {
        public static byte AsByte(this string self)
        {
            return (byte)Convert.ToInt32(self, 2);
        }
    }
