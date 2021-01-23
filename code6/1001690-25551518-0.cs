    List<String> data = new List<String>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["mtable"] != null)
        {
            data = (List<String>)Session["mtable"];
        }
        if (!IsPostBack) BuildTable();
    }
    protected void BuildTable()
    {
        if (Session["mtable"] != null)
        {
            foreach (String s in data)
            {
                TableCell tc = new TableCell();
                tc.Text = s;
                TableRow tr = new TableRow();
                tr.Cells.Add(tc);
                Table1.Rows.Add(tr);
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        data.Add(TextBox1.Text);
        Session["mtable"] = data;
        BuildTable();
    }
