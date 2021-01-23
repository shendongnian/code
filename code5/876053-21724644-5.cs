    public partial class MainPage : PhoneApplicationPage
    {
        ObservableCollection<string> listOne = new ObservableCollection<string>();
        ObservableCollection<string> listTwo = new ObservableCollection<string>();
        myComposite<string> composite;
        public myComposite<string> Composite
        {
            get { return composite; }
            set { composite = value; }
        }
        public MainPage()
        {
            InitializeComponent();
            listOne.Add("First");
            listOne.Add("Second");
            listOne.Add("Third");
            listTwo.Add("Fourth");
            composite = new myComposite<string>(listOne, listTwo);
            myList.ItemsSource = Composite;
        }
    }
