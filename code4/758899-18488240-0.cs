    public partial class Form1 : Form
    {
    
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();
        private readonly Task _task;
    
        public Form1()
        {
            InitializeComponents();
            _task = Task.Factory.StartNew(() => EventLoop(_cts.Token), _cts.Token);
        }
    
        private void EventLoop(CancellationToken token)
        {
            while(!token.IsCancellationRequested)
            {
                // Do work
            }
    
            token.ThrowIfCancellationRequested();
        }
    
        private void ButtonClick(object sender, EventArgs e)
        {
            _cts.Cancel();
        }
    }
