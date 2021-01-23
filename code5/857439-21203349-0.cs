    public static List<int> money = new List<int>();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(Int32));
            dt.Columns.Add("Name");
            dt.Rows.Add();
            dt.Rows[dt.Rows.Count - 1]["ID"] = 1;
            dt.Rows[dt.Rows.Count - 1]["Name"] = "Test1";
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID", typeof(Int32));
            dt2.Columns.Add("Name");
            dt2.Rows.Add();
            dt2.Rows[dt2.Rows.Count - 1]["ID"] = 2;
            dt2.Rows[dt2.Rows.Count - 1]["Name"] = "Test2";
            DataTable dt3 = new DataTable();
            dt3.Columns.Add("ID", typeof(Int32));
            dt3.Columns.Add("Name");
            dt3.Rows.Add();
            dt3.Rows[dt3.Rows.Count - 1]["ID"] = 3;
            dt3.Rows[dt3.Rows.Count - 1]["Name"] = "Test2";
            money = (from row in dt.AsEnumerable() select Convert.ToInt32(row["ID"])).ToList();
            money.AddRange((from row in dt2.AsEnumerable() select Convert.ToInt32(row["ID"])).ToList());
            money.AddRange((from row in dt3.AsEnumerable() select Convert.ToInt32(row["ID"])).ToList());
        }
