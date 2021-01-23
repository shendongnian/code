    namespace MyNameSpace
    {
       public class MyClass
       {
          [DllImport("user32.dll")]
          public static extern short GetAsyncKeyState(int vKey);
       }
    }
