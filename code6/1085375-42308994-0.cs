    using System.Data;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id"), new DataColumn("Name"), new DataColumn("Status") });
            dt.Rows.Add(1, "John Hammond", "Absent");
            dt.Rows.Add(2, "Mudassar Khan", "Present");
            dt.Rows.Add(3, "Suzanne Mathews", "Absent");
            dt.Rows.Add(4, "Robert Schidner", "Present");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
