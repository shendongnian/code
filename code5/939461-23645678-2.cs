    //Simulated datatable
    DataTable table1 = new DataTable();
    table1.Columns.Add(new DataColumn("TaskID", typeof(int)));
    table1.Columns.Add(new DataColumn("GroupID", typeof(int)));
    table1.Columns.Add(new DataColumn("GroupName", typeof(String)));
    //Entered test values
    DataRow dr1 = null;
    dr1 = table1.NewRow();
    dr1["TaskID"] = 12;
    dr1["GroupID"] = 2;
    dr1["GroupName"] = "A";
    table1.Rows.Add(dr1);
    dr1 = table1.NewRow();
    dr1["TaskID"] = 13;
    dr1["GroupID"] = 3;
    dr1["GroupName"] = "B";
    table1.Rows.Add(dr1);
    dr1 = table1.NewRow();
    dr1["TaskID"] = 14;
    dr1["GroupID"] = 2;
    dr1["GroupName"] = "A";
    table1.Rows.Add(dr1);
    dr1 = table1.NewRow();
    dr1["TaskID"] = 15;
    dr1["GroupID"] = 3;
    dr1["GroupName"] = "B";
    table1.Rows.Add(dr1);
    dr1 = table1.NewRow();
    dr1["TaskID"] = 16;
    dr1["GroupID"] = 3;
    dr1["GroupName"] = "B";
    table1.Rows.Add(dr1);
    //solution starts from here
    Dictionary<string, int> totalCount = new Dictionary<string, int>();
    for (int i = 0; i < table1.Rows.Count; i++)
    {
        if (totalCount.Keys.Contains(table1.Rows[i]["GroupName"].ToString()))
        {
            int currVal = totalCount[table1.Rows[i]["GroupName"].ToString()];
            totalCount[table1.Rows[i]["GroupName"].ToString()] = currVal + 1;
        }
        else
        {
            totalCount[table1.Rows[i]["GroupName"].ToString()] = 1;
        }
    }
    foreach (var item in totalCount)
    {
        MessageBox.Show(item.Value.ToString());
    }
