    var myTable = new DataTable();
    myTable.Columns.Add(new DataColumn("AssociateId"));
    myTable.Columns.Add(new DataColumn("Action"));
    myTable.Columns.Add(new DataColumn("Time"));
    var row = myTable.NewRow();
    row["AssociateId"] = 1;
    row["Action"] = "Login";
    row["Time"] = new DateTime(2012, 12, 12, 20, 33, 0);
