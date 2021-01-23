    public class Matrix<T>
    {
        private T[] array;
        public T this[int row, int column]
        {
            get { return array[row + column]; }
        }
    }
