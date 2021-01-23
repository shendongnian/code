    public unsafe struct myPoint
    {
        public const int size=10;
        public fixed double x[size];
        ...
        public double[] X
        {
            get
            {
                double[] res=new double[size];
                fixed (double* ptr=x)
                {
                    for (int i=0; i<size; i++)
                    {
                        res[i]=ptr[i];
                    }
                }
                return res;
            }
            set
            {
                if (value.Length>size) throw new IndexOutOfRangeException();
                fixed (double* ptr=x)
                {
                    for (int i=0; i<value.Length; i++)
                    {
                        ptr[i]=value[i];
                    }
                }
            }
        }
    }
