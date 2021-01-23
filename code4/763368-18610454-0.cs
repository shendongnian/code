    class IntPoint : IDoable<IntPoint>
    { 
        public int x;
        public int y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    
        public void DoSomething(IntPoint p)
        {
            p.x += 10;
            p.y += 10;
        }
    }
