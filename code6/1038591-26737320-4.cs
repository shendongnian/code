    namespace WpfApplication1
    {
        public class MyClass
        {
            public int Integer { get; set; }
            public string Str { get; set; }
        }
    
        public partial class MainWindow : Window
        {
            public ObservableCollection<MyClass> MyCollection { get; set; }
    
            public MainWindow()
            {
                InitializeComponent();
                DataContext = this;
                MyCollection = new ObservableCollection<MyClass>();
    
                Thread t = new Thread(new ThreadStart(() =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                       Dispatcher.Invoke(new Action(() =>
                       {
                        MyCollection.Add(new MyClass()
                        {
                            Integer = i,
                            Str = "String " + i
                        });
                       }));
                    }
                }));
    
                t.Start();
            }
        }
    }
