    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    namespace ExposePrivateVariablesUsingReflection
    {
        class Program
        {
            private class MyPrivateClass
            {
                private string MyPrivateFunc(string message)
                {
                    return message + "Yes";
                }
            }
            static void Main(string[] args)
            {
                var mpc = new MyPrivateClass();
                Type type = mpc.GetType();
                var output = (string)type.InvokeMember("MyPrivateFunc",
                                        BindingFlags.Instance | BindingFlags.InvokeMethod |
                                        BindingFlags.NonPublic, null, mpc,
                                        new object[] {"Is Exposed private Member ? "});
                Console.WriteLine("Output : " + output);
                Console.ReadLine();
            }
        }
    }
