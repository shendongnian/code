        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LanguageDdl.DataSource = new Varmebaronen.AppCode.BO.Object().GetList();
                LanguageDdl.DataBind();
            }
        }
        protected void LanguageDdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if query the database for dataSource like in my case here you can
            // take value of the languagedropdown and fetch the category for the current language
            CategoryDdl.DataSource = new Varmebaronen.AppCode.BO.Category().GetList();
            CategoryDdl.DataBind();
        }
        protected void CategoryDdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            TemplateDdl.DataSource = new Varmebaronen.AppCode.BO.Product().GetList();
            TemplateDdl.DataBind();
        }
        protected void TemplateDdl_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
