    public class Location<TBlock> : ILocation
        where TBlock : ILocation
    {
        public int X { get; set; }
        public int Y { get; set; }
        public TBlock block;
        public Location(int x, int y, TBlock o)
        {
            X = x;
            Y = y;
            block = o;
        }
        public char Symbol()
        {
            return block.Symbol();
        }
    }
