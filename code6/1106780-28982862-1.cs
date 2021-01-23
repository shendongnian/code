    public Form1()
    {
        this.InitializeComponent();
    }
    
    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);
        CheckFirstRun();
    }
    
    private static void CheckFirstRun()
    {
        if(Settings.Default.FirstRun)
        {
            MessageBox.Show(
                "First run");
            Settings.Default.FirstRun = false;
            Settings.Default.Save();
        }
    }
