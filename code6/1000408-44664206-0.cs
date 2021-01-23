    try
            {
               
                if (e.DashboardId == "ASPxDashboardViewer1")
                {
                    string definitionPath = "";
                    string dashboardDefinition;
                    switch (option)
                    {
                        case "A": definitionPath = Server.MapPath("~/A.xml"); break;
                        case "B": definitionPath = Server.MapPath("~/B.xml"); break;
                    }
                    dashboardDefinition = File.ReadAllText(definitionPath);
                    e.DashboardXml = dashboardDefinition;
                }
            }
            catch (Exception ex)
            {
                if (IsCallback)
                {
                    DevExpress.Web.ASPxCallback.RedirectOnCallback("Signout.aspx");
                }
                else
                {
                    Response.Redirect("Signout.aspx");
                }
            }
