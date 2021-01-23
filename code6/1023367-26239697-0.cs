    class Matrix
    {
        public uint Rows { get; private set; }
        public uint Columns { get; private set; }
        private readonly double[,] elements;
        public Matrix(double[,] elements)
        {
            this.elements = elements;
            this.Columns = (uint)elements.GetLength(1);
            this.Rows = (uint)elements.GetLength(0);
        }
        public double this[int x, int y]
        {
          get
          {
            return elements[x, y];
          }
          private set
          {
            elements[x, y] = value;
          }
        }
    }
