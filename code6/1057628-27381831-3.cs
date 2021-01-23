    public struct GridPosition
    {
        public int Row { get; private set; }
        public int Column { get; private set; }
        public GridPosition(int row, int column)
            : this()
        {
            Row = row;
            Column = column;
        }
        public GridPosition(string gridPostion)
            : this()
        {
            Row = Convert.ToInt32(gridPostion.Split(',')[0]);
            Column = Convert.ToInt32(gridPostion.Split(',')[1]);
        }
    }
