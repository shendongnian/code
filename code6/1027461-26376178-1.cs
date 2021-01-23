    [DllImport("mydll.dll", CallingConvention = CallingConvention.Cdecl)]
    private extern static void CreateCalcService(out IntPtr obj);
    [DllImport("mydll.dll", CallingConvention = CallingConvention.Cdecl)]
    private extern static double Multiple(IntPtr obj, double a, double b);
    static void Main(string[] args)
    {
        IntPtr calc;
        CreateCalcService(out handle);
        Multiple(calc, 14, 29);
    }
