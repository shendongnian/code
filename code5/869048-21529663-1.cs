    DataTable dt = new DataTable("TestTable");
    dt.Columns.Add(new DataColumn("email", System.Type.GetType("System.String")));
    dt.Columns.Add(new DataColumn("type", System.Type.GetType("System.String")));
    dt.Columns.Add(new DataColumn("card", System.Type.GetType("System.String")));
    List<string> al = new List<string>(); //Use List<string>
    al.Add("one@mail.com");
    al.Add("two@mail.com");
    al.Add("nine@mail.com");
    al.Add("ten@mail.com");
    DataRow r1 = dt.NewRow(); r1["email"] = "one@mail.com"; //addtype+card// dt.Rows.Add(r1);
    dt.Rows.Add(r1);
    DataRow r2 = dt.NewRow(); r2["email"] = "one@mail.com"; //addtype+card// dt.Rows.Add(r2); //Add Row to DataTable
    dt.Rows.Add(r2);
    DataRow r3 = dt.NewRow(); r3["email"] = "two@mail.com"; //addtype+card// dt.Rows.Add(r3);
    dt.Rows.Add(r3);
    DataRow r4 = dt.NewRow(); r4["email"] = "four@mail.com"; //addtype+card// dt.Rows.Add(r4);
    dt.Rows.Add(r4);
    DataRow r5 = dt.NewRow(); r5["email"] = "five@mail.com"; //addtype+card// dt.Rows.Add(r5);
    dt.Rows.Add(r5);
    DataTable dtNew = dt.AsEnumerable()
                       .Where(r => al.Contains(r.Field<string>("email")))
                       .CopyToDataTable();
