    public struct Square
    {
        private readonly int x;
        private readonly int y;
        public Square(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int X
        {
            get
            {
                return this.x;
            }
        }
        public int Y
        {
            get
            {
                return this.y;
            }
        }
        public static IEnumerable<Radio> CalculateRadios(Square square)
        {
            // Do stuff,
                //// yield return radio; 
            // in a loop.
        }
        public IEnumerable<Radio> CalculateRadios()
        {
            return CalculateRadios(this);
        }
    }
