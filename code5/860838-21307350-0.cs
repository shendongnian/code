          protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    bind();
                }
            }
    protected void bind()
    {
        yourGridId.DataSource = yourdatasource;
        yourGridId.DataBind();
    }
