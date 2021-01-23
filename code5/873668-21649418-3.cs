    if (!Page.IsPostBack)
        {
            
            ddwcategory.DataBind();
            ddwsubcat.DataBind();
            
        }
        else
        {
            if (ddwsubcat.Items.Count <= 1)
            {
                ddwsubcat.SelectedIndex = -1;
                ddwsubcat.DataBind();
            }
          //  Label1.Text = ddwsubcat.SelectedValue;
            //ddwsubcat.DataBind();
        }
        String subcat = ddwsubcat.SelectedValue;
