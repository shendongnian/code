    private class sqrClosure
    {
        public int factor;
        public int srq(int x)
        {
            return x * factor;
        }
    }
    ...
    var c = new sqrClosure();
    c.factor = 2;
    Console.Writeline(c.sqr(3));
    c.factor = 4;
    Console.Writeline(c.sqr(3));
