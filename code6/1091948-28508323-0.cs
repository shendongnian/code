    public sealed partial class MainPage : Page,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int __RandomNumber;
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }
        public int RandomNumber 
        { 
            get{return _RandomNumber} 
            set
            {
                if (_RandomNumber != value){
                  _RandomNumber = value;
                  this.OnPropertyChanged("RandomNumber");//needed for binding
                }
            }; 
        }
        public int GenerateRandomNumber(int min, int max)
        {
            Random random = new Random();
            RandomNumber = random.Next(5,40); //changed this line, do the assign
            return RandomNumber;
        }
        private void ButtonNo3(object sender, RoutedEventArgs e)
        {
            int ans = 0;
            Button obj = (Button)sender;
            var selectedButton = obj.Content.ToString(); 
            //some more code
            GenerateRandomNumber(0,0);  //added : generate a random number
        }
