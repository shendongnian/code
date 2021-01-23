    public static class FortranLib
    {
        private const string _dllName = "FortranLib.dll";
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void ProgressUpdateAction(ref int progress); // Important the int is passed by ref (else we could use built-in Action<T> instead of delegate).
        [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DoWork([MarshalAs(UnmanagedType.FunctionPtr)] ref ProgressUpdateAction progressUpdate);
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                FortranLib.ProgressUpdateAction updateProgress = delegate(ref int p)
                {
                    Console.WriteLine("Progress: " + p + "%");
                };
                FortranLib.DoWork(ref updateProgress);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
