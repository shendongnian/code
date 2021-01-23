    public ActionResult Index()
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable("Marks");
        dt.Clear();
        dt.Columns.Add("Name");
        dt.Columns.Add("Marks");
        DataRow dr = dt.NewRow();
        dr["Name"] = "rami";
        dr["Marks"] = "500";
        dt.Rows.Add(dr);
        ds.Tables.Add(dt);
        return View(ds);
    }
