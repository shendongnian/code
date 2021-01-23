     [DllImport(@"MyDLL.dll", EntryPoint ="Foo", CallingConvention = CallingConvention.StdCall)]
     public static extern void Foo(string str, ResponseDelegate response);
     ...
     
     Foo("Input", s =>
     {
        // response is returned in s - do what you want with it
     });
