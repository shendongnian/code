    public static class Ext
    {
        public static void A(this Object a) { }
        public static void A(this ValueType a) { }
        public static void CallSite() { 1.A(); }
    }
