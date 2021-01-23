    namespace SerializeListWinRT
    {
 
    public sealed partial class MainPage : Page
    {
        private readonly ObservableCollection<Cat> _cats = new ObservableCollection<Cat>();
 
        public ObservableCollection<Cat> Cats
        {
            get { return _cats; }
        }
 
        public MainPage()
        {
            this.InitializeComponent();
            ClearLists();
            AddCatsToList();
            CreateNewCat();
        }
 
        private async void AddCatsToList()
        {
            await LocalStorage.Restore<Cat>();
            SetCatList();
        }
 
        private void ClearLists()
        {
            Cats.Clear();
            LocalStorage.Data.Clear();
        }
 
        private void SetCatList()
        {
            foreach (var item in LocalStorage.Data)
            {
                _cats.Add(item as Cat);
            }
        }
 
        public Cat NewCat { get; set; }
 
        private void CreateNewCat()
        {
            NewCat = new Cat();
        }
 
        private void AddNewCat()
        {
            _cats.Add(new Cat {Name = NewCat.Name, About = NewCat.About});
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
 
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddNewCat();
        }
 
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AddNewCat();
            SaveList();
        }
 
        private void SaveList()
        {
            LocalStorage.Data.Add(NewCat);
            LocalStorage.Save<Cat>();
        }
 
    }
    }
