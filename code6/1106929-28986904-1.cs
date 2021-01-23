    public class Form1
    {
        private Task fooTask;
    
        public Task FooAsync()
        {
            return Task.FromResult(0);
        }
    
        public async void MyEventHandler(object sender, EventArgs e)
        {
            if (fooTask != null && fooTask.Status == TaskStatus.Running)
            {
                // If we got here, the task is currently running
            }
            else
            {
                // It isn't running. Note it could be in a state
                // other than completed such as Faulted or Canceled
                fooTask = await FooAsync();
            }
        }
    }
