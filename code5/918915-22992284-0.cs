    public class Form1<T> : Form
    {
        public Form1(string waitingText, Task<T> task)
        {
            Task = Execute(task);
            Controls.Add(new Label { Text = waitingText });
        }
        
        public T ReturnValue { get { return Task.Result; } }
        public Task<T> Task { get; private set; }
    
        private async Task<T> Execute(Task<T> task)
        {
            var result = await task;
            Close();
            return result;
        }
    }
