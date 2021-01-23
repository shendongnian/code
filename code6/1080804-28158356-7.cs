     private void LoadPages()
     {
         using (var ctx = GetClientContext())
         {
            var items = PagesManager.LoadPages(ctx).Select(i => new
            {
                CreationDate = (DateTime)i["Created"],
                PageName = i["FileLeafRef"],
                PageLink = i["FileRef"].ToString()
            });
            gridPages.ItemsSource = items;
        }
    }
