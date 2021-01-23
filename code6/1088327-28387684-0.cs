    public HomeScreen()
    {
            InitializeComponent();
            SetLabels();
            List<HeadItems> headItems = new List<HeadItems>();
            headItems.Add(new HeadItems("Kyle's Head", 0, 0, 3, 0, 0, 1));
    
            foreach (HeadItems headItem in headItems)
            {
                cboHeads.Items.Add(headItem.Name);
            }
        }
