    //Create source tables
    DataTable dt1 = new DataTable("Employees");
    dt1.Columns.Add("EmployeeID", Type.GetType("System.Int32"));
    dt1.Columns.Add("FirstName", Type.GetType("System.String"));
    dt1.Columns.Add("LastName", Type.GetType("System.String"));
    dt1.Columns.Add("BirthDate", Type.GetType("System.DateTime"));
    dt1.Columns.Add("JobTitle", Type.GetType("System.String"));
    dt1.Columns.Add("DepartmentID", Type.GetType("System.Int32"));
    dt1.Rows.Add(new object[] { 1, "Tommy", "Hill", new DateTime(1970, 12, 31), "Manager", 42 });
    dt1.Rows.Add(new object[] { 2, "Brooke", "Sheals", new DateTime(1977, 12, 31), "Manager", 23 });
    dt1.Rows.Add(new object[] { 3, "Bill", "Blast", new DateTime(1982, 5, 6), "Sales Clerk", 42 });
    dt1.Rows.Add(new object[] { 1, "Kevin", "Kline", new DateTime(1978, 5, 13), "Sales Clerk", 42 });
    dt1.Rows.Add(new object[] { 1, "Martha", "Seward", new DateTime(1976, 7, 4), "Sales Clerk", 23 });
    dt1.Rows.Add(new object[] { 1, "Dora", "Smith", new DateTime(1985, 10, 22), "Trainee", 42 });
    dt1.Rows.Add(new object[] { 1, "Elvis", "Pressman", new DateTime(1972, 11, 5), "Manager", 15 });
    dt1.Rows.Add(new object[] { 1, "Johnny", "Cache", new DateTime(1984, 1, 23), "Sales Clerk", 15 });
    dt1.Rows.Add(new object[] { 1, "Jean", "Hill", new DateTime(1979, 4, 14), "Sales Clerk", 42 });
    dt1.Rows.Add(new object[] { 1, "Anna", "Smith", new DateTime(1985, 6, 26), "Trainee", 15 });
    
    DataTable dt2 = new DataTable("Departments");
    dt2.Columns.Add("DepartmentID", Type.GetType("System.Int32"));
    dt2.Columns.Add("DepartmentName", Type.GetType("System.String"));
    dt2.Rows.Add(new object[] { 15, "Men's Clothing" });
    dt2.Rows.Add(new object[] { 23, "Women's Clothing" });
    dt2.Rows.Add(new object[] { 42, "Children's Clothing" });
    
    var JoinedTables = from t1 in dt1.AsEnumerable()
                        join t2 in dt2.AsEnumerable() on t1["DepartmentID"] equals t2["DepartmentID"]
                        select new {
                            LastName = t1.Field<String>("LastName"),
                            DepartmentName = t2.Field<String>("DepartmentName")
                        };
    
    GridView1.DataSource = JoinedTables;
    GridView1.DataBind();
