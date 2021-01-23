    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var t = Task.Factory.StartNew(() => { 
                    for(var i = 0;i<100;i++)
                    {
                        //object sync = new object(); 
                        //lock (sync)
                        {
                            Console.WriteLine("Writing" + i);
                        }
                    }
                });
                Console.Read();
            }
        }
    }
