    protected void Page_PreRender(object sender, EventArgs e)
    {
       if (!Page.IsPostBack && Session["PageState"] != null)
       {
        NameValueCollection formValues = (NameValueCollection)Session["PageState"];
    
        String[] keysArray = formValues.AllKeys;
        for (int i = 0; i < keysArray.Length; i++)
        {
          Control currentControl = Page.FindControl(keysArray[i]);
          if (currentControl != null)
          {
            if (currentControl.GetType() == typeof(System.Web.UI.WebControls.TextBox)) ((TextBox)currentControl).Text = formValues[keysArray[i]];
            else if (currentControl.GetType() == typeof(System.Web.UI.WebControls.CheckBox))
          {
          if (formValues[keysArray[i]].Equals("on")) ((CheckBox)currentControl).Checked = true;
            }
            else if (currentControl.GetType() == typeof(System.Web.UI.WebControls.DropDownList))
    ((DropDownList)currentControl).SelectedValue = formValues[keysArray[i]].Trim();
          }
        }
      }
    
      if(Page.IsPostBack) Session["PageState"] = Request.Form;
    
    }
    
