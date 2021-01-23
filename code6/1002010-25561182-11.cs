     public partial class MainWindow : Window
    {
        private List<StringModel> lst;
        public List<StringModel> LST
        {
            get { return lst; }
            set { lst = value; }
        }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            LST = new List<StringModel>();
            StringModel vm = new StringModel(new Point(20, 20), "123", 14, Brushes.Red, 2);
            LST.Add(vm);
            vm = new StringModel(new Point(20, 20), "456", 16, Brushes.Blue, 3);
            LST.Add(vm);
            vm = new StringModel(new Point(20, 20), "789", 18, Brushes.Green, 4);
            LST.Add(vm);
        }
    }
