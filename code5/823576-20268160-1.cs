     ObservableCollection<Uri> myList = new ObservableCollection<Uri>();
      public MainPage()
      {
         InitializeComponent();
         myLLS.ItemsSource = myList;
         myList.Add(new Uri("Resources/Image1.png", UriKind.RelativeOrAbsolute));
         myList.Add(new Uri("Resources/Image2.png", UriKind.RelativeOrAbsolute));
      }
