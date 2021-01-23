    GridView1.DataSource = null;
    GridView1.Refresh();
    ServiceReference1.mojWebServiceSoapClient client = new ServiceReference1.mojWebServiceSoapClient();
    var userList = client.getUsers();
    DataTable dt = new DataTable();
    DataColumn column = new DataColumn();
    dt.Columns.Add("ID", typeof(Int32));
    dt.Columns.Add("Name", typeof(string));
    dt.Columns.Add("Last Name", typeof(string));
    foreach (var user in userList)
    {
        DataRow row = dt.NewRow();
        row[0] = user.userID.ToString();
        row[1] = user.Name;
        row[2] = user.lName;
        dt.Rows.Add(row);
    }
    GridView1.DataSource = dt;
    GridView1.DataBind();
