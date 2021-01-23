    protected void Page_Load(object sender, EventArgs e)
    { 
       if(!Page.IsPostBack)
       {
         // other code 
         DataSet Color = new DataSet();
         Color.ReadXml(MapPath("Project/Color.xml"));
         ddlresp.DataSource = Color;
         ddlresp.DataBind();
       }
    }
