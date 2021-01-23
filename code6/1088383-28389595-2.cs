    public HomePage()
    {
        InitializeComponent();
    }
    List<string> list=new List<string>();
      private void ListTransfer()
       {
        SqlDataAdapter da = new SqlDataAdapter("SELECT [Department] FROM [employeeTable]", con);
        DataSet ds = new DataSet();
        da.Fill(ds, "employeeTable");
        List<string> list = new List<string>();
        foreach(DataRow row in ds.Tables["employeeTable"].Rows)
        {
            list.Add(row["Department"].ToString());
        }
       // Department_wise_Employee_Details dep = new Department_wise_Employee_Details(list);
       }
    Department_wise_Employee_Details fourthForm = new Department_wise_Employee_Details(list);
    private void btn1_Click(object sender, EventArgs e)
    {
        fourthForm.Show();
    }
