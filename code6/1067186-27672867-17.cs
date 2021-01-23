    public newDepartment()
    {
        InitializeComponent();
        inputDepartmentName.Text = "Hi";
        dbConnetion db = new dbConnetion();
        foreach(string name in db.getDataSet("SELECT name FROM test;", null, r => r["name"].ToString() ))
        {
           //Do Something
        }
    }
