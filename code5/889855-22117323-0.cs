    var mutex = new object();
    int number = 0;
    var task = Task.Factory.StartNew<bool>(() =>
    {
        TaskFactory ts = new TaskFactory(TaskCreationOptions.AttachedToParent, TaskContinuationOptions.ExecuteSynchronously);
        foreach (var item in collection)
        {
            if (item.BoolProp)
            {
                ts.StartNew(() =>
                {
                    var value = GetNum1(item.IntProp);
                    lock (mutex) number += value;
                });
            }
            else
            {
                ts.StartNew(() =>
                {
                    var value = GetNum2(item.IntProp);
                    lock (mutex) number += value;
                });
            }
        }
        return true;
    });
    task.Wait();
    lock (mutex)
        Console.WriteLine(number);
