    public static class BFactory
    {
        public static B CreateFromA(A a)
        {
            B result = new B();
            result.T1 = a.T1;
            result.T2 = a.T2;
            result.T3 = a.T3;
            result.T4 = a.T4;
            result.T5 = 0;
            return result;
        }
    }
