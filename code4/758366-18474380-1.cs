    private void GetQueryString(Uri tempUri)
    {
      ddlTopics.DataSource = SqlDSTypes.Select(DataSourceSelectArguments.Empty);
      ddlTopics.DataBind();
      //Put your logic here, behind databind ...
      if (HttpUtility.ParseQueryString(tempUri.Query).Get("IntrestFocus") != null)
      {
          ddlTopics.SelectedValue = HttpUtility.ParseQueryString(tempUri.Query).Get("IntrestFocus"); 
      }
      else
          if (HttpUtility.ParseQueryString(tempUri.Query).Get("Skills") != null)
          {
            ddlSkills.SelectedValue = HttpUtility.ParseQueryString(tempUri.Query).Get("Skills"); 
          }
      else
          if(HttpUtility.ParseQueryString(tempUri.Query).Get("Type") != null)
          {
            ddlTypes.SelectedValue = HttpUtility.ParseQueryString(tempUri.Query).Get("Type"); 
          }
    }
