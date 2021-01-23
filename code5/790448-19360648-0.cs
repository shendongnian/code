    public partial class MainPage : PhoneApplicationPage
    {
       private ObservableCollection<string> collection = new ObservableCollection<string>();
       public MainPage()
       {
         InitializeComponent();
         phoneLLS.DataContext = collection;
         addBtn.Click += addBtn_Click;
         delBtn.Click += delBtn_Click;
         showBtn.Click += showBtn_Click;
       }
       ...
    }
