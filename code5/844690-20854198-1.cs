    protected void Page_Load(object sender, EventArgs e)
    {
            //fill gridview
            if( ! IsPostBack )
            {
                GridView1.DataSource = SqlDataSource1;
                GridView1.DataBind();
            }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
            string name = e.Row.Cells[2].Text;            
            Image img = (Image)e.Row.FindControl("Image1");
            if (img==null)
            {
                return;
            }
            if(name == "XYZ")
            {
                img.ImageUrl = "~/Images/a.jpg";
            }
            else if(name == "XPS")
            {
                  img.ImageUrl = "~/Images/b.jpg";
            }
            else
            {
                //default static image
                img.ImageUrl = "~/Images/c.jpg";
            }
    }
