    namespace WpfApplication1
    {
        public class MyClass
        {
            public int Integer { get; set; }
            public string Str { get; set; }
        }
    
        public partial class MainWindow : Window
        {
            private ObservableCollection<MyClass> _MyCollection;
            public ObservableCollection<MyClass> MyCollection { get; set; }
            
            public MainWindow()
            {
                InitializeComponent();
                DataContext = this;
                MyCollection = new ObservableCollection<MyClass>();
                _MyCollection = new ObservableCollection<MyClass>();
                _MyCollection.CollectionChanged += new NotifyCollectionChangedEventHandler(_MyCollection_CollectionChanged);
    
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
            }
    
            private void _MyCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                Dispatcher.Invoke(new Action(
                    () =>
                    {
                        foreach (var item in e.NewItems)
                            MyCollection.Add((MyClass)item);
                    }));
            }
        }
    }
