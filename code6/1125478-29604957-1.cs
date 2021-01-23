    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<string> competitors = Request.Cookies["TauLucompetitors"].Value.ToString().Select(x => x.ToString()).ToList();
            TauluGridcompetitors.DataSource = competitors;
            TauluGridcompetitors.DataBind();
        }
    }
    protected void TauluGridcompetitors_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DropDownList DDL1;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DDL1 = (DropDownList)e.Row.FindControl("NoWeaponDDL");
            DDL1.DataSource = BindXml("XML/NoWeapon.xml").Tables[0];
            DDL1.DataTextField = "Type";
            DDL1.DataValueField = "ID";
            DDL1.DataBind();
        }
    }
    private DataSet BindXml(string fileName)
    {
        string filePath = "~/" + fileName;
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath(filePath));
        return ds;
    }
