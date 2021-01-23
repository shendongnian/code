    public string ActiveItem { get; set; }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (ActiveItem != null)
        {
            if (ActiveItem == "Home")
                HomeList.CssClass = "active";
            if (ActiveItem == "About")
                HomeAbout.CssClass = "active";
            if (ActiveItem == "Store")
                HomeStore.CssClass = "active";
        }
    }
