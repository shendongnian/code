      protected void Page_Load(object sender, EventArgs e)
      {
         if (!IsPostBack)
         {
            ddlMeals.DataBind();
            if(ddlMeals.Items.Count > 0)
            {
                ddlMeals.SelectedIndex = 0;
                ddlMeals_SelectedIndexChanged(null, EventArgs.Empty);
            }
      }
