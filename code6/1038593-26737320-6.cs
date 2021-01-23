    public partial class MainWindow : Window
        {
            private List<MyClass> _MyCollection;
            public ObservableCollection<MyClass> MyCollection { get; set; }
            
            private DispatcherTimer dispatcherTimer = new DispatcherTimer();
    
            public MainWindow()
            {
                InitializeComponent();
                DataContext = this;
                MyCollection = new ObservableCollection<MyClass>();
                _MyCollection = new List<MyClass>();
                dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 500);
                dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
    
                Thread t = new Thread(new ThreadStart(() =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        _MyCollection.Add(new MyClass()
                        {
                            Integer = i,
                            Str = "String " + i
                        });
                        Thread.Sleep(500);
                    }
                }));
    
                t.Start();
                dispatcherTimer.Start();
            }
    
            private void dispatcherTimer_Tick(object sender, EventArgs e)
            {
                if (_MyCollection.Count != MyCollection.Count)
                {
                    MyCollection.Add(_MyCollection[_MyCollection.Count - 1]);
                }
            }
        }
