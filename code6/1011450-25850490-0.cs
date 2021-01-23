    var dt = new DataTable();
    dt.Columns.Add("ID");
    dt.Rows.Add(new object[]{ 1 });
    dt.Rows.Add(new object[]{ 2 });
    dt.Rows.Add(new object[]{ 3 });
    var sqlParam = new SqlParameter("MyTable", dt){ TypeName = "B" };
    var query = db.Database.SqlQuery<CModel>("A @MyTable", sqlParam);
    var cmodels = query.ToList();
