    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            gvTest.DataSource = new int[] { 1, 2, 3 };
            gvTest.DataBind();
        }
    }
    protected void gvTest_RowCreated(object sender, GridViewRowEventArgs e)
    {
	    //note: e.Row.DataItem will be null during postback
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Controls.Add(new TextBox());
        }
    }
    protected void gvTest_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            var txtBox = (TextBox)e.Row.Cells[0].Controls[0];
            txtBox.Text = e.Row.DataItemIndex.ToString();
        }
    }
    protected void Clear_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvTest.Rows)
        {
            var txtBox = (TextBox)row.Cells[0].Controls[0];
            //txtBox.Text will have whatever value the user gave it client side
            txtBox.Text = "";
        }
    }
