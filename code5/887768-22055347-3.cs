    // ViewModel
    public class TaskFailedEventArgs: EventArgs
    {
        public Exception Exception { get; private set; }
        public bool Handled { get; set; }
        public TaskFailedEventArgs(Exception ex) { this.Exception = ex; }
    }
    public event EventHandler<TaskFailedEventArgs> TaskFailed = delegate { };
    public ViewModel()
    {
        this.TaskFailed += (s, e) =>
        {
            // handle it, e.g.: retry, report or set a property
            MessageBox.Show(e.Exception.Message);
            e.Handled = true;
        };
        _initTask = InitAsync();
        //Now where do I check on the status of the init task?
    }
    private async Task InitAsync()
    {
        try
        {
            // do the async work
        }
        catch (Exception ex)
        {
            var args = new TaskFailedEventArgs(ex);
            this.TaskFailed(this, args);
            if (!args.Handled)
                throw;
        }
    }
    // application
    public void ShowWindow()
    {
        var vm = new ViewModel(); //Previously this could throw an exception that would prevent window from being shown
        _windowServices.Show(vm);
    }
