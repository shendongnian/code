    private void longlist_ItemRealized(object sender, ItemRealizationEventArgs e)
        {
            Search.BindSearch search = e.Container.Content as Search.BindSearch;
            if (search != null)
            {
                int offset = 0;
                if (OCollectionBindSearch.Count - OCollectionBindSearch.IndexOf(search) <= offset)
                {
                    longlist.ScrollTo(search);
                }                
            }
        }
