    public partial class Form1 : Form
    {
        // CancellationTokenSource will hold the CancellationToken struct
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();
        // Task will hold the logic
        private readonly Task _task;
    
        public Form1()
        {
            InitializeComponents();
            // The task will be started on the ThreadPool off the Dispatcher thread
            _task = Task.Factory.StartNew(() => EventLoop(_cts.Token), _cts.Token);
        }
    
        private void EventLoop(CancellationToken token)
        {
            while(!token.IsCancellationRequested)
            {
                // Do work
            }
            // This exception will be handled by the Task
            // and will not cause the program to crash
            token.ThrowIfCancellationRequested();
        }
    
        private void ButtonClick(object sender, EventArgs e)
        {
            _cts.Cancel();
        }
    }
