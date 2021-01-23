    public struct MyKey
    {
        private ushort row;
        private ushort col;
    
        public int Row { get { return row; } }
        public int Col { get { return col; } }
    
        public MyKey(int row, int col)
        {
            // check if keys are in range between 0 and ushort.MaxValue
            if(row < 0 || row > ushort.MaxValue || col < 0 || col > ushort.MaxValue)
                throw new ArgumentOutOfRangeException(string.Format("Arguments row and col cannot be less than 0 or greater than {0}.", ushort.MaxValue));
            this.row = (ushort) row;
            this.col = (ushort) col;
        }
    
        // Overriden GetHashCode() that's used by the Dictionary to search through the keys.
        public override int GetHashCode()
        {
            // we just shift Row by 16 Bits to left and make a bitwise or with Col to generate the Hashcode
            return ((int) row << 16) | col;
        }
    }
