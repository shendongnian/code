    BackgroundWorker _worker;
    // button click starts the execution of the lung running task on another thread
    private void button1_Click(object sender, EventArgs e)
    {
        label1.Visible = true; // show the label "please wait"
        _worker.RunWorkerAsync();
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        // initialize worker
        _worker = new BackgroundWorker();
        _worker.DoWork += new DoWorkEventHandler(worker_DoWork);
        _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_worker_RunWorkerCompleted);
    }
    // executes when long running task has finished
    void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        // hide the label
        label1.Visible = false;
    }
    // is called by 'RunWorkerAsync' and executes the long running task on a different thread
    void worker_DoWork(object sender, DoWorkEventArgs e)
    {
        // long running task (just an example)
        for (int i = 0; i < 1000000000; i++)
        {
        }
    }
