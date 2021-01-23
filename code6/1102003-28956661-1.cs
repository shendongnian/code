    #region page load
                if (!IsPostBack)
                {
                    if (User.IsInRole("admin") || User.IsInRole("superuser"))
                    {
                    }
                    else
                    {
                        string unAuthorizedRedirect = WebConfigurationManager.AppSettings["UnAuthorizedRedirect"];
                        Response.Redirect("~/" + unAuthorizedRedirect);
                    }
                }
                #endregion
