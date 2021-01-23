    public class Data
    {
        public string textFirst { get; set; }
        public string textSecond { get; set; }
        public string textThird { get; set; }
    }
    public partial class MainPage : PhoneApplicationPage
    {
        ObservableCollection<Data> dataReceived = new ObservableCollection<Data>();
        public MainPage()
        {
            InitializeComponent();
            myList.ItemsSource = dataReceived;
        }
        // and to add data you do it like this:
        dataReceived.Add(new Data() { textFirst = "First text", textSecond = "Second Text", textThird = "Third one" });
