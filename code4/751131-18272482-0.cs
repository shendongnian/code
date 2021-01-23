    class A
        {
            private string _x, _y, _z;
    
            public string x { get { return _x; } set { _x = value; } }
            public string y { get { return _y; } set { _y = value; } }
            public string z { get { return _z; } set { _z = value; } }
        }
    public partial class MainWindow : Window
        {
            private List<A> myData;
    
            public MainWindow()
            {
                InitializeComponent();
    
                myData = new List<A>();
                myData.Add(new A() { x = "x1", y = "y1" });
                myData.Add(new A() { x = "x2", y = "y2" });
                myData.Add(new A() { x = "x3", y = "y3" });
    
                dataGrid1.ItemsSource = myData;
            }
        }
