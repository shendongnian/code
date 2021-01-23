    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {       
            Image img = new Image();
            img.ImageUrl = "~/Contents/Images/asc.png";
            GridView1.HeaderRow.Cells[1].Controls.Add(new LiteralControl(" "));
            GridView1.HeaderRow.Cells[1].Controls.Add(img);
        }
    }
