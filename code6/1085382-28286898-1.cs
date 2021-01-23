    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopulateMenu();
        }
    }
    
    private void PopulateMenu()
    {
        MyMenu.Items.Add(new MenuItem
        {
            Text = "Home",
            Value = "Home",
            NavigateUrl = "~/Accounts/Menu.aspx"
        });
    
    
        MyMenu.Items.Add(new MenuItem
        {
            Text = "Search/Register for Classes",
            Value = "Search/Register for Classes",
            NavigateUrl = "~/Registration/SearchCourses.aspx"
        });
    
    
        if (User.IsInRole("Learner"))
        {
            MyMenu.Items.Add(new MenuItem
            {
                Text = "Transcript",
                Value = "Transcript",
                NavigateUrl = "~/InserviceHistory/InserviceTranscript.aspx"
            });
            MyMenu.Items.Add(new MenuItem
            {
                Text = "Request for In-Service Credit",
                Value = "Request for In-Service Credit",
                NavigateUrl = "~//InserviceCredit/IndividualRequest/InstructionalIndividualCreditRequest.aspx"
            });
        }
    
        if (User.IsInRole("Admin") || User.IsInRole("Coord") || User.IsInRole("Instr"))
        {
            var usersMenuItem = new MenuItem
            {
                Text = "Users",
                Value = "Users",
                NavigateUrl = "~/Accounts/Users.aspx"
            };
    
            usersMenuItem.ChildItems.Add(new MenuItem
            {
                Text = "Add",
                Value = "Add",
                NavigateUrl = ""
            });
            usersMenuItem.ChildItems.Add(new MenuItem
            {
                Text = "Edit",
                Value = "Edit",
                NavigateUrl = ""
            });
            usersMenuItem.ChildItems.Add(new MenuItem
            {
                Text = "Delete",
                Value = "Delete",
                NavigateUrl = ""
            });
    
            MyMenu.Items.Add(usersMenuItem);
        }
    
        if (User.IsInRole("Admin") || User.IsInRole("Coord"))
        {
            var coordinatorsMenuItem = new MenuItem
            {
                Text = "Coordinators",
                Value = "Coordinators",
                NavigateUrl = "~/Accounts/Users.aspx"
            };
    
            coordinatorsMenuItem.ChildItems.Add(new MenuItem
            {
                Text = "Add",
                Value = "Add",
                NavigateUrl = ""
            });
            coordinatorsMenuItem.ChildItems.Add(new MenuItem
            {
                Text = "Edit",
                Value = "Edit",
                NavigateUrl = ""
            });
            coordinatorsMenuItem.ChildItems.Add(new MenuItem
            {
                Text = "Delete",
                Value = "Delete",
                NavigateUrl = ""
            });
    
            MyMenu.Items.Add(coordinatorsMenuItem);
        }
    }
