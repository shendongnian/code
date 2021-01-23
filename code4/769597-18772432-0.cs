    public static class Extensions
    {
        public static Int32 toInt(this string me)
        {
            return Convert.ToInt32(me, 2);
        }
    }
    (...)
    var myflags = "00010010".toInt();
    (...)
