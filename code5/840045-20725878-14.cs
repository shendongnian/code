    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //PopulateGridView
            PopulateGrid();
        }
        lnkChekall.Attributes.Add("onclick", "javascript:SelectAll(true)");
        lnkUncheck.Attributes.Add("onclick", "javascript:SelectAll(false )");
     
    }
