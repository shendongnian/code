    private void Start()
    {
       while(true)
           DoSomething();
    }
    protected override void OnStart(string[] args)
    {
       Task.Factory.StartNew(() => Start());
    }
