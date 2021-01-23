    class TaskState
    {
        public int OneSecondTaskId { get; set; }
        public int TenSecondTaskId { get; set; }
        public bool ShouldRescheduleOneSecondTask { get; set; }
        public bool ShouldRescheduleTenSecondsTask { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Task oneSecondTask = null;
            Task tenSecondTask = null;
            var state = new TaskState()
                            {
                                ShouldRescheduleOneSecondTask = true,
                                ShouldRescheduleTenSecondsTask = true
                            };
            while (true)
            {
                if (state.ShouldRescheduleOneSecondTask)
                {
                    oneSecondTask = Task.Factory.StartNew(
                        () =>
                        {
                            Thread.Sleep(1000);
                            Console.WriteLine("Slept 1 second");
                        });
                    state.OneSecondTaskId = oneSecondTask.Id;
                    state.ShouldRescheduleOneSecondTask = false;
                }
                if (state.ShouldRescheduleTenSecondsTask)
                {
                    tenSecondTask = Task.Factory.StartNew(
                        () =>
                        {
                            Thread.Sleep(10000);
                            Console.WriteLine("Slept 10 seconds");
                        });
                    state.TenSecondTaskId = tenSecondTask.Id;
                    state.ShouldRescheduleTenSecondsTask = false;
                }
                var handleTaskCompletionTask = Task.WhenAny(oneSecondTask, tenSecondTask).ContinueWith(
                    (completedTask, o) =>
                    {
                        var taskState = (TaskState)o;
                        var taskId = completedTask.Result.Id;
                        if (taskId == taskState.OneSecondTaskId)
                        {
                            taskState.ShouldRescheduleOneSecondTask = true;
                        }
                        if (taskId == taskState.TenSecondTaskId)
                        {
                            taskState.ShouldRescheduleTenSecondsTask = true;
                        }
                    }, state);
                handleTaskCompletionTask.Wait();
            }
        }
    }
