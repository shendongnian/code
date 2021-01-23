    var tasks = new Task[] {
        ((Func<Task>)(async () =>
        {
            await Task.Delay(10);
            await Task.Delay(10);
            await Task.Delay(10);
            throw new Exception("First");
        }))(),
        ((Func<Task>)(async () =>
        {
            await Task.Delay(10);
            throw new Exception("Second");
        }))(),
        ((Func<Task>)(async () =>
        {
            await Task.Delay(10);
        }))()
    };
    var allTasks = Task.WhenAll(tasks);
    try
    {
        await allTasks;
    }
    catch (Exception ex)
    {
        Console.WriteLine("Overall failed: {0}", ex.Message);
    }
    
    for(var i = 0; i < tasks.Length; i++)
    {
        try
        {
            await tasks[i];
            Console.WriteLine("Taks {0} succeeded!", i);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Taks {0} failed!", i);
        }
    }
    /*
    Overall failed: First
    Taks 0 failed!
    Taks 1 failed!
    Taks 2 succeeded!
    */
