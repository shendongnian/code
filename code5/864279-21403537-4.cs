    class SomeClass
    {
       public static ObservableCollection<MyData> myObservableCollection = new ObservableCollection<MyData>();
    }
    class MyData
    {
       public string someData { set; get; }
    }
    public MainPage()
    {
       InitializeComponent();
       MyItemsControl.ItemsSource = SomeClass.myObservableCollection;
       SomeClass.myObservableCollection.Add(new MyData() { someData = "First" });
       SomeClass.myObservableCollection.Add(new MyData() { someData = "Second" });
    }
