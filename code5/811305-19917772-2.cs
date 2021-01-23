        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDataSource();
                adminXML.Visible = true;
            }
        }
        protected void adminXML_RowCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                /*
                Do Delete
                */
                BindDataSource();
            }
        }
        private void BindDataSource()
        {
            XmlDataSource xmlDS = new XmlDataSource();
            xmlDS.EnableCaching = false;
            xmlDS.DataFile = "~/App_Data/resdat.xml";
            xmlDS.TransformFile = "~/App_Data/adminFormat.xslt";
            xmlDS.XPath = "/resdat/entry";
            adminXML.DataSource = xmlDS;
            adminXML.DataBind();
        }
