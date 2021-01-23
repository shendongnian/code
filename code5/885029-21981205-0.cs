    using System;
    using System.Runtime.InteropServices;
    namespace ConsoleApplication1
    {
        [ComVisible(true)]
        public interface IClass1
        {
            string Test(string aStr);
        }
        [ComVisible(true)]
        public class Class1 : IClass1
        {
            public string Test(string aStr)
            {
                if (aStr == null) return "[null]";
                if (aStr == "") return "[empty]";
                return "Not empty: " + aStr;
            }
        }
        class Program
        {
            [DllImport(@"Project1.dll")]
            static extern void Foo(IClass1 intf);
            static void Main(string[] args)
            {
                IClass1 intf = new Class1();
                Foo(intf);
            }
        }
    }
