    public partial class MainWindow : Window
    {  
    public MainWindow()
    {
        InitializeComponent();
        MyList = new List<MyItem>();
        MyList.Add(new MyItem { Name = "" });
        MyList.Add(new MyItem { Name = "" });
        this.DataContext = this;
    }
    public List<MyItem> MyList { get; set; }
}
    public class MyItem
    {
        public string Name { get; set; }
     }
