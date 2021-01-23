    static async Task OneTestAsync(int n)
    {
        await Task.Delay(n);
    }
    
    static Task AnotherTestAsync(int n)
    {
        return Task.Delay(n);
    }
    
    // call DoTestAsync with either OneTestAsync or AnotherTestAsync as whatTest
    static void DoTestAsync(Func<int, Task> whatTest, int n)
    {
        Task task = null;
        try
        {
            // start the task
            task = whatTest(n);
    
            // do some other stuff, 
            // while the task is pending
            Console.Write("Press enter to continue");
            Console.ReadLine();
            task.Wait();
        }
        catch (Exception ex)
        {
            Console.Write("Error: " + ex.Message);
        }
    }
