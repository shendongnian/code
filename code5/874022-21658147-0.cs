    public class Matrix<T>
        where T : struct, 
            IComparable<T>,
            IConvertible,
            IEquatable<T>,
            IFormattable
    {
        private readonly T[,] matr;
        public int rows;
    
        public int Rows
        {
            get { return rows; }
        }
    
        public int Cols
        {
            get { return cols; }
        }
    
        public int cols;
    
        public Matrix(T[,] table)
        {
            matr = table;
            rows = matr.GetLength(0);
            cols = matr.GetLength(1);
        }
