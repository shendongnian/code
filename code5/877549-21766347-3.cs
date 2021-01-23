    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct myPoint
    {        
        public const int size = 10;
        public fixed double x[size];
        public fixed double y[size];
        public fixed double z[size];
        public void Initialize(int n, double d1)
        {
            fixed (double* x_ptr=x, y_ptr=y, z_ptr=z)
            {
                for (int i=0; i<size; i++)
                {
                    x_ptr[i]=(i+1)*d1;
                    y_ptr[i]=(i+1)*d1;
                    z_ptr[i]=0.0;
                }
            }
        }
    }
    class Program
    {
        [DllImport(@"FortranDll1.dll", CallingConvention=CallingConvention.Cdecl)]
        public unsafe static extern void CalcPoint(ref myPoint t);
        unsafe Program()
        {
            double d1=1.0;
            var T=new myPoint();
            T.Initialize(10, d1);
            Program.CalcPoint(ref T);
            // T.z = {2,4,6,...}
        }
        static void Main(string[] args)
        {
            new Program();
        }
    }
