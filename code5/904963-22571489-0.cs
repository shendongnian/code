    public ObservableCollection<ManPowerOrg> MyList = new ObservableCollection<ManPowerOrg>();
      public Window1()
        {
            InitializeComponent();
           
            using (DesignerEntities db = new DesignerEntities())
            {
                foreach (var item in db.ManPowerOrgs.ToList())
                {
                    MyList.Add(item);
                }
            }
           DataContext = this;
        }
     private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (DesignerEntities db = new DesignerEntities())
            {
                ManPowerOrg myItem = new ManPowerOrg() {Caption = "A", Number = 1, SMonth = 100};
                db.ManPowerOrgs.Add(myItem);
                db.SaveChanges();
                MyList.Add(myItem);
            }
        }
