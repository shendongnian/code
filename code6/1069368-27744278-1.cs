    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            MastersClient objIndent = new MastersClient();
            DataSet ds = objIndent.GetIndent(hidIndentID.Value);
            ProductRepeater.DataSource = ds.Tables[0].Select("IndentID =" + hidIndentID.Value);
            ProductRepeater.DataBind();
        }
    }
