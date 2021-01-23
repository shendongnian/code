    var tasks = new Action[] {Task1, Task2, Task3};
    foreach(var task in tasks)
    {
        try
        {
           task();
        }
        catch (Exception ex)
        {
        }
    }
