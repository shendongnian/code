    public class Matrix
    {
        private readonly double[,] _elements;
        public uint Rows { get { return (uint)elements.GetLength(0);} }
        public uint Columns { get { return (uint)elements.GetLength(1);} }
    
        public Matrix(double[,] elements)
        {
            this._elements = elements;
        }
    
        public double this[int x, int y]
        {
          get
          {
            return elements[x, y];
          }
       }
    }
