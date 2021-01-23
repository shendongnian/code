    public class Matrix<T> : Collection<T>
    {
        int row_count, col_count;
        List<T> _list; //reference to inner list
        T[] _items; //reference to inner array within inner list
        // the above are used for fast array copying.
        public Matrix(int row_count, int col_count)
            : base(new List<T>(new T[row_count*col_count]))
        {
            // internal data arranged in 1D array, by rows.
            this._list=base.Items as List<T>;
            this.row_count=row_count;
            this.col_count=col_count;
            LinkInnerArray();
        }
        private void LinkInnerArray()
        {
            this._items=typeof(List<T>).GetField("_items",
                System.Reflection.BindingFlags.NonPublic
                |System.Reflection.BindingFlags.Instance).GetValue(base.Items) as T[];
        }
        public int RowCount { get { return row_count; } }
        public int ColCount { get { return col_count; } }
        public T this[int row, int col]
        {
            get { return base[col_count*row+col]; }
            set { base[col_count*row+col]=value; }
        }
        public T[] GetRow(int row)
        {
            if(row<0||row>=row_count) new IndexOutOfRangeException();
            T[] result=new T[col_count];
            lock(_items)
            {
                // fast array copy
                Array.Copy(_items, col_count*row, result, 0, result.Length);
            }
            return result;
        }
        public T[] GetColumn(int column)
        {
            if(column<0||column>=col_count) new IndexOutOfRangeException();
            T[] result=new T[row_count];
            lock(_items)
            {
                // No shortcut exists. Only of C# was more like FORTRAN
                for(int i=0; i<row_count; i++)
                {
                    result[i]=base[col_count*i+column];
                }
            }
            return result;
        }
        public void SetRow(int row, params T[] values)
        {
            if(values==null||values.Length==0) return;
            if(row<0||row>=row_count) new IndexOutOfRangeException();
            // fast array copy
            lock(_items)
            {
                Array.Copy(values, 0, _items, col_count*row, values.Length);
            }
        }
        public void SetColumn(int column, params T[] values)
        {
            if(values==null||values.Length==0) return;
            if(column<0||column>=col_count) new IndexOutOfRangeException();
            lock(_items)
            {
                // No shortcut exists. Only of C# was more like FORTRAN
                for(int i=0; i<values.Length; i++)
                {
                    base[col_count*i+column]=values[i];
                }
            }
        }
        public void AddRow(params T[] new_row)
        {
            lock(_list)
            {
                // add array to last row
                T[] row=new T[col_count];
                Array.Copy(new_row, 0, row, 0, new_row.Length);
                _list.AddRange(row);
                LinkInnerArray();
                this.row_count++;
            }
        }
        public void AddColumn(params T[] new_column)
        {
            lock(_list)
            {
                // go add an item on end of each row
                for(int i=row_count-1; i>=0; i--)
                {
                    T item=i<new_column.Length?new_column[i]:default(T);
                    _list.Insert(col_count*i+row_count-1, item);
                }
                LinkInnerArray();
                this.col_count++;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int N=4;
            var A=new Matrix<int>(N, N);
            // initialize diagonal
            for(int i=0; i<N; i++)
            {
                A[i, i]=1;
            }
            // A = 
            // | 1  0  0  0 |
            // | 0  1  0  0 |
            // | 0  0  1  0 |
            // | 0  0  0  1 |
            A.AddRow(5, 4, 3, 2);
            A.AddColumn(1, 2, 3, 4, 5);
            // A = 
            // | 1  0  0  0  1 |
            // | 0  1  0  0  2 |
            // | 0  0  1  0  3 |
            // | 0  0  0  1  4 |
            // | 5  4  3  2  5 |
        }
    }
