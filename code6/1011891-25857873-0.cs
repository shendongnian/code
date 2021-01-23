    class LinkedMatrix<T>
    {
        int LowerY;
        int UpperY;
    
        public int TotalColums
        {
            get;
            private set;
        }
    
        LinkedMatrix<T> Next;
    
        T[,] InternalArray;
    
        public LinkedMatrix(int rows, int cols)
        {
            InternalArray = new T[rows, cols];
            UpperY = rows;
            TotalColums = cols;
        }
    
        private LinkedMatrix(int lowerY, int addedRows, int colums)
        {
            InternalArray = new T[addedRows, colums];
            LowerY = lowerY;
            UpperY = LowerY + addedRows;
        }
    
        public void AppendRows(int addedRows)
        {
            LinkedMatrix<T> LastNotNull = this;
            while( LastNotNull.Next != null )
            {
                LastNotNull = LastNotNull.Next;
            }
    
            LastNotNull.Next = new LinkedMatrix<T>(LastNotNull.UpperY, addedRows, this.TotalColums);
        }
    
        public T this[int y, int x]
        {
            get
            {
                if( y >= UpperY  )
                {
                    if( Next != null)
                    {
                        return Next[y, x];
                    }
                    else
                    {
                        throw new IndexOutOfRangeException();
                    }
                }
                else if( y >= LowerY )
                {
                    return InternalArray[y - LowerY, x];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
    
            set
            {
                if (y >= UpperY)
                {
                    if (Next != null)
                    {
                        Next[y,x] = value;
                    }
                    else
                    {
                        throw new IndexOutOfRangeException();
                    }
                }
                else if (y >= LowerY)
                {
                    InternalArray[y - LowerY, x] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
    }
        
    
    class Program
    {
        static void Main(string[] args)
        {
            LinkedMatrix<string> matrix = new LinkedMatrix<string>(1, 1);
            matrix[0, 0] = "0,0";
            matrix.AppendRows(1);
            matrix[1, 0] = "1,0";
        }
    }
