    public class LibWrapper
    {
       [DllImport("SomeLib.dll" )]
       public static extern void TakesAnArray(int size, [In, Out] int[] array);
    }
