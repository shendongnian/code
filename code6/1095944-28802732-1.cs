    public sealed partial class MainPage : Page
    {
        public List<TempList> ListDataSource = new List<TempList>();
        public MainPage()
        {
            this.InitializeComponent();
            FillList();           
        }
        private void FillList()
        {
            ListDataSource.Clear();
            ListDataSource.Add(new TempList { BgColor = "Red" });
            ListDataSource.Add(new TempList { BgColor = "Red" });
            MyList.ItemsSource = ListDataSource;
        }
    }
    public class TempList
    {
        public string BgColor { get; set; }
    }
