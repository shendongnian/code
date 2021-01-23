    public class MyPage : Page
    {
        public Dependency Dep { get; set; }
        public ObservableCollection<Foo> AllDeps { get; set; }
        public MyPage()
        {
            AllDeps = new ObservableCollection<Foo>();
            InitializeComponent();
            // initialize Dep
            foreach (var d in Dep.GetAll())
            {
                AllDeps.Add(d);
            }
        }
    }
