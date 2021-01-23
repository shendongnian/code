    class W : IAnalysis
    {
        W(X x, Y y, …)
        {
            this.x = x;
            this.y = y;
            …
        }
        public IAnalysis CreateObject()
        {
            return new W(x, y, …);
        }
    }
