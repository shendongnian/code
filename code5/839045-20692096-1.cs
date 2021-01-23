    public delegate void P_HelloWord();
    public struct FUNC_PARAM
    {
        public P_HelloWord pHelloWorld;
    }
    [DllImport(@"MyDll.dll", CallingConvention = CallingConvention.Cdecl)]
    public extern static void Func4(ref FUNC_PARAM pFunc);
    static void Main(string[] args)
    {
        FUNC_PARAM pFunc;
        pFunc.pHelloWorld = myHelloWorld;
        Func4(ref pFunc);
        Console.ReadLine();
    }
    static void myHelloWorld()
    {
        Console.WriteLine("Boo!");
    }
