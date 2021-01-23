    private IGeneratorPage view;
    private Timer timer;
    private SynchronizationContext uiSyncContext;
    public GeneratorPagePresenter()
    {
        uiSyncContext = SynchronizationContext.Current;
    }
    public void SetView(IGeneratorPage generatorPage)
    {
        view = generatorPage;
        timer = new Timer();
        timer.Interval = 1000;
        timer.AutoReset = true;
        timer.Elapsed += Timer_Elapsed;
    }
    void Timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        uiSyncContext.Post((state) => view.UpdateProgress(percentage), null);                
    }
