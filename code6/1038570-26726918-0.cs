    void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
    {
        var isp = (ItemsStackPanel)listview.ItemsPanelRoot;
        int firstVisibleItem = isp.FirstVisibleIndex;
        e.PageState["FirstVisibleItemIndex"] = firstVisibleItem;
        
        // This must be serializable according to the SuspensionManager
        e.PageState["Followers"] = this.DefaultViewModel["Followers"];
    }
    void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
    {
        // Do we have saved state to restore?
        if (e.PageState != null)
        {
            // Restore list view items
            this.DefaultViewModel["Followers"] = (WhateverType)e.PageState["Followers"];
            // Restore scroll offset
            var index = (int)e.PageState["FirstVisibleItemIndex"];
            var container = listview.ContainerFromIndex(index);
            listview.ScrollIntoView(container);
        }
        else
        {
            // Load data for the first time
            var userId = e.NavigationParameter as string;
            List<User> followers = GetFollowers(userId);
            this.DefaultViewModel["Followers"] = followers;
        }
    }
