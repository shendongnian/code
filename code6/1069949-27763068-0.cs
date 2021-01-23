    class A
    {
        public event Func<object, EventArgs, Task> Shutdown;
        public async Task OnShutdown()
        {
            Func<object, EventArgs, Task> handler = Shutdown;
            if (handler == null)
            {
                return;
            }
            Delegate[] invocationList = handler.GetInvocationList();
            Task[] handlerTasks = new Task[invocationList.Length];
            for (int i = 0; i < invocationList.Length; i++)
            {
                handlerTasks[i] = ((Func<object, EventArgs, Task>)invocationList[i])(this, EventArgs.Empty);
            }
            await Task.WhenAll(handlerTasks);
        }
    }
