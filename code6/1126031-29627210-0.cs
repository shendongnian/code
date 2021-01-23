    private void Do404()
    {
        Item item404 = Sitecore.Context.Database.GetItem(Settings.Error404ID);
        Sitecore.Web.WebUtil.Redirect(LinkManager.GetItemUrl(item404));
    }
