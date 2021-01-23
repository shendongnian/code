    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Custom Transactions");
                var t = new CustomTransaction();
                for (int i = 0; i < 100; ++i )
                    t.StartTransaction();
            }
        }
        class CustomTransaction
        {
            public void StartTransaction()
            {
                Console.WriteLine("StartTransaction");     
                Dummy();
            }
            void Dummy()
            {
                System.Threading.Thread.Sleep(5000);
            }
        }
    
    }
