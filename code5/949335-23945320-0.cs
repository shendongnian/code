    public static class Ext
    {
        public static void A(this IComparable<int> a) { }
        public static void A(this ValueType a) { }
        public static void CallSite() { 1.A(); }
    }
