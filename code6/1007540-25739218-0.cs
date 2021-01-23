     if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                int id = Convert.ToInt32(Request.QueryString.Get("id"));
                //---- Now here you can get your complete article by using id and display on page.
            }
        }
