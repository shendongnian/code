    public MainPage()
    {
       InitializeComponent();
       System.Threading.Timer myTimer = new Timer(MyTimerCallback);
       myTimer.Change(1000, 10);
    }
    private static int value = 0;
    private static void MyTimerCallback(object state)
    {
       value++;
    }
