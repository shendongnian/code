        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlMeals.DataSource=BindData(); // this function gets the data u need to bind to your drop down.
                ddlMeals.DataBind();
                if(ddlMeals.Items.Count > 0)
                {
                    ddlMeals.SelectedIndex = 0;
                    ddlMeals_SelectedIndexChanged(null, EventArgs.Empty);
                }
            }
        }
