    protected void Page_Load(object sender, EventArgs e)
    {   
        var pageUrl = GetCurrentPageName();
    }
    private void SetNavigationLabel()
    {
        RadMenu NavigationMenu = (RadMenu)this.FindControl("RadMenu1");
        foreach (RadMenuItem m in NavigationMenu.Items)
        {
            if (Request.Url.AbsoluteUri.ToLower() == Server.MapPath(Request.Url.AbsolutePath.ToLower()) || m.Selected)
            {
                string sPagePath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
                System.IO.FileInfo oFileInfo = new System.IO.FileInfo(sPagePath);
                string sPageName = "~/" + oFileInfo.Name;
                oFileInfo = null;
                var navName1 = NavigationMenu.FindItemByUrl(Request.RawUrl);
                var navName = navName1.Text;
                lblNavTitle.Text = navName;
                ((IDisposable)NavigationMenu).Dispose();
                break;
            }
        }
    }
    public string GetCurrentPageName()
    {
         var sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
         FileInfo oInfo = new FileInfo(sPath);
         var sReturn = oInfo.Name;
         oInfo = null;
         return sReturn;
    }
