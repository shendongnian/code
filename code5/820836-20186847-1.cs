    protected void grdPractices_OnRowEditing(object sender, GridViewEditEventArgs e)
    {
      this.grdPractices.EditIndex = e.NewEditIndex;
      var vCheckBox = this.grdPractices.Rows[e.NewEditIndex].Controls[0].FindControl("chkSites") as CheckBox;
      if (vCheckBox == null)
      {
         return;
      }
    }
