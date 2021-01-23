    protected void Page_Load(object sender, EventArgs e)
        {
            ...
            this.GridGroupingControl1.DataSourceControlRowAdding += new GridDataSourceControlRowAddingEventHandler(GridGroupingControl1_DataSourceControlRowAdding);
        }
    void GridGroupingControl1_DataSourceControlRowAdding(object sender,   GridDataSourceControlRowAddingEventArgs e)
        {
            List<Orders> records = new List<Orders>();
            if(ViewState["AddedRecord"] != null)
            {
                records = (List<Orders>)ViewState["AddedRecord"];
            }
            Orders obj = new Orders();
            obj.LastName = e.NewValues[0].ToString();
            obj.FirstName = e.NewValues[1].ToString();
            records.Add(obj);
            ViewState["AddedRecord"] = records;
            e.Cancel = true;
            e.Handled = true;
        }
    private void SaveChanges()
        {
            if (ViewState["AddedRecord"] != null)
        {
            myConnection = new SqlCeConnection(ConnectionString);
            myConnection.Open();
            List<Orders> records1 = new List<Orders>();
            records1 = (List<Orders>)ViewState["AddedRecord"];
            foreach (var temp in records1)
            {
                SqlCeCommand command1 = new SqlCeCommand();
                command1.Connection = myConnection;
                command1.CommandText="INSERT INTO Employees([Last Name], [First Name]) VALUES(@LastName,@FirstName)";
                command1.Parameters.AddWithValue("@LastName", temp.LastName);
                command1.Parameters.AddWithValue("@FirstName", temp.FirstName);
                command1.ExecuteNonQuery();
            }
            ViewState["AddedRecord"] = null;
            myConnection.Close();
        }
        }
