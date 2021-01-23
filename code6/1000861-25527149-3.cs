    internal static class NativeMethods
    {
       [DllImport("SomeLib.dll" )]
       public static extern void TakesAnArray(int size, [In, Out] int[] array);
    }
