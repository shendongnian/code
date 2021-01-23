            if (!Page.IsPostBack)
            {
                int x = DateTime.Now.Year;
                List<string> str = new List<string>();
    
                for (int i = x; i >= 1975; i--)
                {
    
                    str.Add(i.ToString());
                }
    
                ddlYear.DataSource = str;
                ddlYear.DataBind();
            }
