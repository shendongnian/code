    class Matrix
        {
            private uint Rows { get; private set; }
            private uint Columns { get; private set; }
            private double[,] Elements { get; private set; }
    
            public Matrix(double[,] elements)
            {
                this.Elements = elements;
                this.Columns = (uint)elements.GetLength(1);
                this.Rows = (uint)elements.GetLength(0);
            }
    
            public double GetElement(int row, int column)
            {
                return this.elements[row, column];
            }
        }
