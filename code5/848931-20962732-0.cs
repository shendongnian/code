    @Html.ActionLink(site.Name, 
                     "SelectSite", 
                     "SettingsController", 
                     new { environmentID = Model.EnvironmentID, siteId = site.SiteID}, null)
    public ActionResult SelectSite(int environmentID, int siteId)
        {    
            //..code here
        }
