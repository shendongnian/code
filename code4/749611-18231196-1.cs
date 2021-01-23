        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataSet ds = new DataSet();//your datasource from database
                rptImage.DataSource = ds;
                rptImage.DataBind();
            }
        }
