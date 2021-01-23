     protected void Page_Load(object sender, EventArgs e)
    {
      if (IsPostBack == false)
      {
        DataTable date = new DataTable();
        date.Columns.Add("Column !", typeof(string));
        date.Columns.Add("Column 2", typeof(string));
        Session["dte"] = date;
      }
    }
    protected void addbutton_Click(object sender, ImageClickEventArgs e)
    {
      DataTable date = (DataTable)Session["dte"];
      DataRow dr = date.NewRow();
      dr["Column 1"] = TextBox1.Text.Trim();// Your Values
      dr["Column 2"] = TextBox2.Text.Trim();// Your Values
      date.Rows.Add(dr);
      GridView1.DataSource = date;
      GridView1.DataBind();
     }
