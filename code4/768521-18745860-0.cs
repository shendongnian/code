    private void OnQueryCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            if (Model.Count == 0)
            {
                CurrentRegionViewModel = null;
            }
            if (args.Action == NotifyCollectionChangedAction.Add)
            {
                RegionQuery addedRegionQuery = args.NewItems.OfType<RegionQuery>().FirstOrDefault();
                if (addedRegionQuery != null)
                {
                    string name = addedRegionQuery.RegionName;
                    while (Model.Any(q => q.RegionName == name && q != addedRegionQuery))
                    {
                        name += "*";
                    }
                    addedRegionQuery.RegionName = name;
                }
            }
