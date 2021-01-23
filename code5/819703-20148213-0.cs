    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace throw_test
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    try
                    {
                        // line 22 below
                        Method();
                    }
                    catch (Exception ex)
                    {
                        // line 30 below
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex.StackTrace);
                }
                Console.Read();
            }
            public static void Method()
            {
                throw new Exception();
            }
        }
    }
