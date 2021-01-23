    private ManualResetEventSlim _Listen;
    public async void Start()
    {
        _Listen = new ManualResetEventSlim(true);
        Task.Factory.StartNew(() => Listen(1);
        Task.Factory.StartNew(() => Listen(2);
    }
    
    public void Stop()
    {
        _Listen.Reset();
    }
    
    private async void Listen(int port)
    {
         var tcp = new TcpClient();
         while(_Listen.IsSet)
         {
