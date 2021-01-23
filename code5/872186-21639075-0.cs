    AsyncOp _asyncOp = new AsyncOp();
    CancellationTokenSource _myFunctionCts = new CancellationTokenSource();
    public MainWindow()
    {
        InitializeComponent();
        this.Loaded += MainWindow_Loaded;
        this.SizeChanged += MainWindow_SizeChanged;
    }
    void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        _asyncOp.RunAsync(MyFunctionAsync, _myFunctionCts.Token);
    }
    void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        _asyncOp.RunAsync(MyFunctionAsync, _myFunctionCts.Token);
    }
    async Task MyFunctionAsync(CancellationToken token)
    {
        int width = (int)this.Width;
        var text = await Task.Run(() =>
        {
            // simulate some useful CPU-bound work
            var result = 0;
            for (var i = 0; i < width; i++)
            {
                token.ThrowIfCancellationRequested();
                result += i;
            }
            return width.ToString() + "/" + result.ToString();
        });
        // update UI (or ViewModel)
        this.TextBlock.Text = text;
    }
