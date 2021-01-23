    System.Timers.Timer timer = null;
    public FrmMain()
    {
        InitializeComponent();
        timer = new System.Timers.Timer(60000);
        timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        //If you want OnTimedEvent to happen on the UI thread instead of a ThreadPool thread, uncomment the following line.
        //timer.SynchronizingObject = this;
        if(this.components == null)
            this.components = new System.ComponentModel.Container();
        //This makes it so when the form is disposed the timer will be disposed with it.
        this.componets.Add(timer);
    }
    private void frmMain_Load(object sender, EventArgs e)
    {
        timer.Start();
    }
    private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        //It is good practice not to do complicated logic in a event handler
        // if we move the logic to its own method it is much easier to test (you are writing unit tests, right? ;) )
        CheckAlert();
    }
    void CheckAlert()
    {
        //do work here
    }
    private void frmMain_Close(object sender, EventArgs e)
    {
        timer.Stop();
    }
