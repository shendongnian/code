    public class MyData
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public MyData(string name, int count)
        {
            Name = name;
            Count = count;
        }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var data = new List<MyData>
                {
                    new MyData("one", 10), 
                    new MyData("two", 100500), 
                    new MyData("three", 777)
                };
            MyDataGrid.ItemsSource = data;
        }
    }
