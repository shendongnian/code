    public static class TaskWithExceptionHandling
    {
        public static Task StartNew(Action action)
        {
            var task = Task.Factory.StartNew(action);
            task.ContinueWith(exceptionHandler, TaskContinuationOptions.OnlyOnFaulted);
            return task;
        }
        private static void exceptionHandler(Task task)
        {
            // Handle unhandled aggregate task exception from 'task.Exception' here.
            Console.WriteLine("Exception: " + task.Exception.GetBaseException().Message);
        }
    }
