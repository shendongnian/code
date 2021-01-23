    TaskFactory taskFactory = new TaskFactory(new TimeLimitedTaskScheduler(5));
    for (int i = 0; i < 50; i++)
    {
        var x = taskFactory.StartNew<int>(() => DateTime.Now.Second)
                            .ContinueWith(t => Console.WriteLine(t.Result));
    }
    Console.WriteLine("End of Loop");
---
    public class TimeLimitedTaskScheduler : TaskScheduler
    {
        int _TaskCount = 0;
        Stopwatch _Sw = null;
        int _MaxTasksPerSecond;
        public TimeLimitedTaskScheduler(int maxTasksPerSecond)
        {
            _MaxTasksPerSecond = maxTasksPerSecond;
        }
        protected override void QueueTask(Task task)
        {
            if (_TaskCount == 0) _Sw = Stopwatch.StartNew();
            var shouldWait = (1000 / _MaxTasksPerSecond) * _TaskCount - _Sw.ElapsedMilliseconds;
            if (shouldWait < 0)
            {
                shouldWait = _TaskCount = 0;
                _Sw.Restart();
            }
                
            Task.Delay((int)shouldWait)
                .ContinueWith(t => ThreadPool.QueueUserWorkItem((_) => base.TryExecuteTask(task)));
            _TaskCount++;
        }
        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            return base.TryExecuteTask(task);
        }
        protected override IEnumerable<Task> GetScheduledTasks()
        {
            throw new NotImplementedException();
        }
            
    }
