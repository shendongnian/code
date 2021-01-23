    private void LogWindow_ContextMenuOpening(object sender, ContextMenuEventArgs e)
    {
       var hyperlink = (Mouse.DirectlyOver as Run)?.Parent as Hyperlink;
       if(hyperlink != null)
       {
           //do whatever you want with the link now
           //e.g. set the command param on a named menu item  
           MenuItem item = this.UriCopyMenuItem;
           item.CommandParameter = hyperlink.NavigateUri;
           item.Visibility = Visibility.Visible;
           ...
        }
    }
