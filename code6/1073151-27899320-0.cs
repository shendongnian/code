    varCollectionview = new CollectionViewSource();
            varCollectionview.Source = cfg.variablen;
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, new Action(delegate()
                {
            varCollectionview.View.SortDescriptions.Add(new SortDescription("varType", ListSortDirection.Descending));
            varCollectionview.View.SortDescriptions.Add(new SortDescription("name", ListSortDirection.Ascending));
            varCollectionview.View.GroupDescriptions.Add(new PropertyGroupDescription("varType"));
            varCollectionview.View.Filter = new Predicate<object>(filter);
            varCollectionview.View.Refresh();
                }));
