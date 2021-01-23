    public Form1()
        {
            InitializeComponent();
            contact c = new contact();
            c.Friend = new person { Name = "ali", Phone = Util.ToDescriptionString(phone.homeNumber)  };
            propertyGrid1.SelectedObject = c;
        }
