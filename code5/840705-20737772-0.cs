    [SetUp]
    public void SetupTest()
    {
        _input = new Mock<IInput>();
        _input.SetupProperty(i => i.QuitKey, 'q');
        _messenger = new Mock<IMessenger>();
        _grid = new Mock<IGrid>();
        _clock = new Mock<IClock>();
        
        new Thread(() =>
        {
            Thread.CurrentThread.IsBackground = true;
                
            IInput input = _input.Object;
            IMessenger messenger = _messenger.Object;
            IGrid grid = _grid.Object;
            IClock clock = _clock.Object;
            _game = new Game(input, messenger, grid, clock);
            _game.GameLoop();
        }).Start();
    }
