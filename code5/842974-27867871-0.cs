    public UserControl1()
    {
        InitializeComponent();
        Application.Idle += Application_Idle;
    }
    
    void Application_Idle(object sender, EventArgs e)
    {
        Thread.Sleep(200); //Yeah VS IDE will sleep for 200 ms ! LOL!
    }
