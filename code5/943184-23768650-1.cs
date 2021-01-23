    public class Matrix<T> : Collection<T>
    {
        int row_count, col_count;
        List<T> _list; //reference to inner list
        T[] _items; //reference to inner array within inner list
        public Matrix(int row_count, int col_count)
            : this(row_count, col_count, new T[row_count*col_count])
        {
            if(row_count==0||col_count==0)
            {
                throw new NotSupportedException();
            }
        }
        Matrix(int row_count, int col_count, T[] values)
            : base(new List<T>(values))
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
        public T[] Elements { get { return _list.ToArray(); } }
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
                // No shortcut exists, only if C# was more like FORTRAN
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
                // No shortcut exists, only if C# was more like FORTRAN
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
        public Matrix<R> Transform<R>(Func<T, R> operation)
        {
            R[] values=new R[row_count*col_count];
            for(int i=0; i<values.Length; i++)
            {
                values[i]=operation(base[i]);
            }
            return new Matrix<R>(row_count, col_count, values);
        }
        public Matrix<R> Combine<R>(Matrix<T> other, Func<T, T, R> operation)
        {
            R[] values=new R[row_count*col_count];
            for(int i=0; i<values.Length; i++)
            {
                values[i]=operation(base[i], other[i]);
            }
            return new Matrix<R>(row_count, col_count, values);
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
            var B=A.Transform(delegate(int x) { return 5-x; });
            // B = 
            // | 4  5  5  5  4 |
            // | 5  4  5  5  3 |
            // | 5  5  4  5  2 |
            // | 5  5  5  4  1 |
            // | 0  1  2  3  0 |
            var C=A.Combine(B, delegate(int x, int y) { return y-x; });
            // C = 
            // | 3  5  5  5  3 |
            // | 5  3  5  5  1 |
            // | 5  5  3  5 -1 |
            // | 5  5  5  3 -3 |
            // |-5 -3 -1  1 -5 |
        }
    }
