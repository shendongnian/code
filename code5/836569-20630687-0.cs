    public class SomeTask 
    {
        int count = 0;
        public int Count { get { return count; } }
        public void Process()
        {
            while(true)
            {
                //some repeated task
                count++;
                if (something)
                    break;
            }
        }        
    }
    var someTasks = new List<SomeTask>();
    for (int i = 0; i < maxTasks; i++)
    {
        var someTask = new SomeTask();
        someTasks.Add(someTask);
        this.Tasks[i] = Task.Factory.StartNew(() => someTask.Process());
    }
    Task.WaitAll(this.Tasks);
    // Your total count
    var total = someTasks.Sum(t => t.Counter);
