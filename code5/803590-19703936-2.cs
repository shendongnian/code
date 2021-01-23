    class Program
            {
                static void Main(string[] args)
                {
                    try
                    {
                        Task task = Task.Delay(1000)
                        .ContinueWith(t => Program.throwsException());
        
                        task.Wait();     
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception:" + ex.Message); // Outputs: Exception:One or more errors occurred.
                        Console.WriteLine("Inner exception:" + ex.InnerException.Message); // Outputs: Exception:thrown
                    }
                    Console.ReadKey();
        
                }
                static void throwsException()
                {
                    Console.WriteLine("Method started");
                    throw new Exception("thrown");
                }
            }
