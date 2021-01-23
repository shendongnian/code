    static void Main(string[] args)
    {
         var t = WhenAll.WaitForAllAsync();
         t.ContinueWith((task) =>
         {
             string[] result = task.Result;
             foreach(string taskname in result)
             {
                 Console.WriteLine("Result: " + taskname);
             }
         });
         t.Wait();
         Console.ReadLine();
    }
