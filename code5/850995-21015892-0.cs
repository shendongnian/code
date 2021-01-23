    public static class interop
    {
        [DllImport("YourDllName.dll")]
        static extern public int nGetSomeThing(void);
    }
    ...
    interop.nGetSomething() // call to the native function
