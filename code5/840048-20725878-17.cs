    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Test Data
            var lst = new List<string>() { "Row 1", "Row 2", "Row 3" };
            GridView1.DataSource = lst;
            GridView1.DataBind();
        }
    
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            var chk = row.FindControl("chk1") as CheckBox;
            if (chk != null && chk.Checked)
            {
                row.Attributes.Add("style", "display:none");
            }
        }
    }
