    protected void Page_Load(object sender, EventArgs e)
    {
    
        if (!this.Page.IsPostBack)
        {
            //Panel1.Visible = false; Comment
            PopulateCategory();
            getSubCategories(CategoryDropDownList.SelectedValue);
            //CategoryDropDownList_SelectedIndexChanged(null, null);
        }
    }
    // To hide:
     Panel1.Style.Add("display", "none");
    // To show:
     Panel1.Style.Add("display", "block");
