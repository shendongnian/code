    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.ExceptionServices;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
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
                        throw new Exception();
                    }
                    catch (Exception ex) // NO 'ex'
                    {
                        // line 30 below
                        ExceptionDispatchInfo.Capture(ex).Throw();
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex.StackTrace);
                }
                Console.Read();
            }
        }
    }
