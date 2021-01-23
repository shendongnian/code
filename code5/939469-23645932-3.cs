    DataTable dt = new DataTable("test1");
    dt.Columns.AddRange(new DataColumn[] { new DataColumn("TASKID"), new DataColumn("GROUPID"), new DataColumn("GROUPNAME") });
    dt.Rows.Add(new object[] { 12, 2, "A" });
    dt.Rows.Add(new object[] { 13, 3, "B" });
    dt.Rows.Add(new object[] { 12, 2, "A" });
    dt.Rows.Add(new object[] { 14, 3, null });
    dt.Rows.Add(new object[] { 15, 3, "B" });
    var query = (from DataRow row in dt.Rows
                    group row by row["GROUPNAME"] into g
                    select g).ToDictionary(x => (x.Key.ToString() == "" ? "*" : x.Key.ToString()), x => (int)((x.Count() * 100) / dt.Rows.Count));
