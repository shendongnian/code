    public partial class MainPage : PhoneApplicationPage
    {
        ObservableCollection<Parent> parentGroups = new ObservableCollection<Parent>();
        public ObservableCollection<Parent> ParentGroups
        {
            get { return parentGroups; }
            set { parentGroups = value; }
        }
        public MainPage()
        {
            InitializeComponent();
            this.parentLB.DataContext = this;
            FillParents();
        }
        public void FillParents()
        {
            Parent p = new Parent { Name = "Tom" };
            Child c1 = new Child { Name = "Tammy" };
            Child c2 = new Child { Name = "Timmy" };
            p.Children.Add(c1);
            p.Children.Add(c2);
            ParentGroups.Add(p);
            p = new Parent { Name = "Carol" };
            c1 = new Child { Name = "Carl" };
            c1.HasHighSchoolDegree = true;
            c1.HasUniversityDegree = true;
            c2 = new Child { Name = "Karla" };
            p.Children.Add(c1);
            p.Children.Add(c2);
            ParentGroups.Add(p);
        }
    }
