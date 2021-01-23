    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
            MenuItem m = new MenuItem("Upload");
            m.NavigateUrl = "~/Uploader/Upload.aspx";
            NavigationMenu.Items.Add(m);
        }
    }
