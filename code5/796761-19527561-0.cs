    public class Example
    {
       public static void Main()
       {
          // Create the task object by using an Action(Of Object) to pass in the loop 
          // counter. This produces an unexpected result.
          Task[] taskArray = new Task[10];
          for (int i = 0; i < taskArray.Length; i++) {
             taskArray[i] = Task.Factory.StartNew( (Object obj) => {
                                                     var data = new CustomData() {Name = i, CreationTime = DateTime.Now.Ticks}; 
                                                     data.ThreadNum = Thread.CurrentThread.ManagedThreadId;
                                                     Console.WriteLine("Task #{0} created at {1} on thread #{2}.",
                                                                       data.Name, data.CreationTime, data.ThreadNum);
                                                   },
                                                  i );
          }
          Task.WaitAll(taskArray);     
       }
    }
