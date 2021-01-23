    using System;
    using System.Runtime.InteropServices;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            const string dllname = @"Project1.dll";
    
            [DllImport(dllname, CharSet = CharSet.Unicode)]
            static extern void Foo(
                string InputVal,
                [MarshalAs(UnmanagedType.BStr)]
                out string OutputVal
            );
    
            [DllImport(dllname)]
            static extern void Bar(
                [MarshalAs(UnmanagedType.BStr)]
                string InputVal,
                [MarshalAs(UnmanagedType.BStr)]
                out string OutputVal
            );
            
            static void Main(string[] args)
            {
                string OutputVal;
                Foo("Hello", out OutputVal);
                Console.WriteLine(OutputVal);
                Bar("World", out OutputVal);
                Console.WriteLine(OutputVal);
            }
        }
    }
