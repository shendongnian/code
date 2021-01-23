    public struct Area3
    {
        byte[] map;
        int rows, columns, pages;
        public Area3(int rows, int columns, int pages)
        {
            this.map=new byte[rows*columns*pages];
            this.columns=columns;
            this.rows=rows;
            this.pages=pages;
        }
        public Area3(Area3 other)
            : this(other.rows, other.columns, other.pages)
        {
            Array.Copy(other.map, this.map, other.map.Length);
        }
        public Area3(byte[, ,] array)
        {
            this.rows=array.GetLength(0);
            this.columns=array.GetLength(1);
            this.pages=array.GetLength(2);
            this.map=new byte[rows*columns*pages];
            for (int i=0; i<rows; i++)
            {
                for (int j=0; j<columns; j++)
                {
                    for (int l=0; l<pages; l++)
                    {
                        this.map[(l*rows+i)*columns+j]=array[i, j, l];
                    }
                }
            }
        }
        public int Rows { get { return rows; } }
        public int Columns { get { return columns; } }
        public int Pages { get { return pages; } }
        public byte[] Map { get { return map; } }
        public byte this[int index]
        {
            get { return map[index]; }
            set { map[index]=value; }
        }
        public byte this[int row, int column, int page]
        {
            get { return map[(page*rows+row)*columns+column]; }
            set { map[(page*rows+row)*columns+column]=value; }
        }
        public byte[, ,] ToArray3()
        {
            byte[, ,] array=new byte[rows, columns, pages];
            for (int i=0; i<rows; i++)
            {
                for (int j=0; j<columns; j++)
                {
                    for (int l=0; l<pages; l++)
                    {
                        array[i, j, l]=map[(l*rows+i)*columns+j];
                    }
                }
            }
            return array;
        }
        public void Spread()
        {
            bool changed;
            do
            {
                changed=false;
                for (int k=0; k<map.Length; k++)
                {
                    byte x=map[k];
                    if (x<=1) continue; // cannot affect neighbors
                    int l=k/(rows*columns);
                    int i=(k%(rows*columns))/columns;
                    int j=(k%(rows*columns))%columns;
                    int k_N=i>0?(l*rows+i-1)*columns+j:-1;
                    int k_S=i<rows-1?(l*rows+i+1)*columns+j:-1;
                    int k_E=j<columns-1?(l*rows+i)*columns+j+1:-1;
                    int k_W=j>0?(l*rows+i)*columns+j-1:-1;
                    int k_U=l<pages-1?((l+1)*rows+i)*columns+j:-1;
                    int k_D=l>0?((l-1)*rows+i)*columns+j:-1;
                    if (k_N>=0&&map[k_N]+1<x) { map[k_N]=(byte)(x-1); changed=true; }
                    if (k_S>=0&&map[k_S]+1<x) { map[k_S]=(byte)(x-1); changed=true; }
                    if (k_E>=0&&map[k_E]+1<x) { map[k_E]=(byte)(x-1); changed=true; }
                    if (k_W>=0&&map[k_W]+1<x) { map[k_W]=(byte)(x-1); changed=true; }
                    if (k_U>=0&&map[k_U]+1<x) { map[k_U]=(byte)(x-1); changed=true; }
                    if (k_D>=0&&map[k_D]+1<x) { map[k_D]=(byte)(x-1); changed=true; }
                }
            } while (changed);
        }
    }
