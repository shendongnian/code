    private void BindHeaderDropDown(string columnName, DataTable dt, string controlName)
    {
      System.Web.UI.HtmlControls.HtmlSelect objControlName = (System.Web.UI.HtmlControls.HtmlSelect)gvDailyTracker.HeaderRow.FindControl(controlName);
      DataView view=new DataView(dt);
      DataTable distinctValues = view.ToTable(true, columnName);
      objControlName.DataSource = distinctValues;
      objControlName.DataTextField = columnName;
      objControlName.DataValueField = columnName;
      objControlName.DataBind();
      // check if it is post-back
      objControlName.Text = Latest User value;
    }
