    public static int Calculate()
    {
      // Simulate some work
      int sum = 0;
      for (int i = 0; i < 10000; i++)
      {
        sum += i;
      }
      return sum;
    }
    // ...
    var task = System.Threading.Tasks.Task.Run(() => Calculate());
    int result = task.Result; // waits/blocks until the task is finished
