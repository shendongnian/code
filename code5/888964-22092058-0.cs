    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string[,] arrMultiD = {
                { "John", "21", "Berlin", "Germany" },
                { "Smith", "33" ,"London", "UK"},
                { "Ryder", "15" ,"Sydney", "Australia"},
                { "Jake", "18", "Tokyo", "Japan"},
                { "Tom","34" , "Mumbai", "India"}
             };
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", Type.GetType("System.String"));
            dt.Columns.Add("Age", Type.GetType("System.String"));
            dt.Columns.Add("City", Type.GetType("System.String"));
            dt.Columns.Add("Country", Type.GetType("System.String"));
            for (int i = 0; i < 5; i++)
            {
                dt.Rows.Add();
                dt.Rows[dt.Rows.Count - 1]["Name"] = arrMultiD[i, 0];
                dt.Rows[dt.Rows.Count - 1]["Age"] = arrMultiD[i, 1];
                dt.Rows[dt.Rows.Count - 1]["City"] = arrMultiD[i, 2];
                dt.Rows[dt.Rows.Count - 1]["Country"] = arrMultiD[i, 3];
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
