    protected void SetMenuItem(string valuePath, bool visible, string url)
    {
        var item = Menu.FindItem(valuePath);
        if (item != null)
        {
            if (url != null)
                item.NavigateUrl = url;
            item.Enabled = visible;
        }
    }
