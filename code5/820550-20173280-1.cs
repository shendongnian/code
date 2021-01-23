    public partial class MainWindow : MetroWindow
    {
     public ViewModel _viewModel;
     private  Dispatcher dispathcer = Dispatcher.CurrentDispatcher;
     public MainWindow()
     {
        InitializeComponent();
        _viewModel = new ViewModel();
        _viewModel.client.AuthorizationSucceeded += ServiceClient_AuthorizationSucceeded;
        _viewModel.client.AuthorizationFailed += ServiceClient_AuthorizationFailed;
        _viewModel.client.RequestStarted += ServiceClient_RequestStarted;
        _viewModel.client.RequestFinished += ServiceClient_RequestFinished;
        this.DataContext = _viewModel;
    }
    void ServiceClient_RequestStarted(SMServiceEventArgs args)
    {
       dispathcer.Invoke(new Action(() => { overlayThrobber.Visibility = System.Windows.Visibility.Visible; }), DispatcherPriority.Normal);
    }
    void ServiceClient_RequestFinished(SMServiceEventArgs args)
    {
        dispathcer.Invoke(new Action(() => { overlayThrobber.Visibility = System.Windows.Visibility.Collapsed; }), DispatcherPriority.Normal);
    }
