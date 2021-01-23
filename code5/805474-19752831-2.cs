    class example
    {
        static void UpdateStatus(int i)
        {
            // UpdateStatus
            Console.WriteLine(i + "Done!");
        }
    
        static void Main(string[] args)
        {
            int state = 0;
            Task t = Task.Run(
                  () =>
                  {
                      // do your stuff - this is going to run async
                      for (int i = 0; i < 10; i++)
                          file.move(file,dst);
                          UpdateStatus(i); // callback to update status 
                      }
                  }
                );
            Console.WriteLine("Started"); // You wont block this code by running the async part
            t.Wait(); 
            Console.WriteLine("DONE");
            Console.ReadKey();
    
        }
    }
