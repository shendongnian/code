    public class Form1
    {
        private Task fooTask = Task.FromResult(0);
    
        public Task FooAsync()
        {
            return Task.FromResult(0);
        }
    
        public async void MyEventHandler(object sender, EventArgs e)
        {
            if (fooTask.Status == TaskStatus.Running)
            {
                // If we got here, the task is currently running. Notify someone
                return;
            }
            // If we're here, the task isn't running.
        }
    }
