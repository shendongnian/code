    static class ExtensionMethods
    {
        public static Task ContinueOnUI(this Task task, Action continuation)
        {
            return task.ContinueWith((arg) =>
            {
                Dispatcher.CurrentDispatcher.Invoke(continuation);
            });
        }
    }
