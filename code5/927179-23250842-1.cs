    //Your window Constructor
    public MyWindow()
    {
        InitializeComponent();
        this.Cursor = Cursors.WaitCursor; 
        this.Enabled = false;
        WaitSomeTime();
        //load stuff
        .....
    }
    public async void WaitSomeTime()
    {
        await Task.Delay(5000);
        this.Enabled = true;
        this.Cursor = Cursors.Default; 
    }
