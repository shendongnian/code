    enum E { }
    static class Ext
    {
        public static E X(this E e) { return e; }
    }
    // Legal
    E e1 = 0;
    // Legal
    E e2 = e.X();
    // No way José.
    E e3 = 0.X();
