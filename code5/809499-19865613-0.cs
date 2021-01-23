    using System;
    using System.Threading.Tasks;
    
    class Test
    {
        static void Main(string[] args)
        {
            DoSomething(10).Wait();
        }
        
        public static async Task DoSomething(int x)
        {
            try
            {
                // Asynchronous implementation.
                await Task.Run(() => {
                    throw new Exception("Bang!");
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("I caught an exception! {0}", ex.Message);
            }
        }
    }
