    ObservableCollection<MyItem> MasterCollection;
    ObservableCollection<MyItem> FilteredCollection;
    bool IsRed, IsYellow, IsGreen; 
    UpdateFilteredCollection()
    {
        FilteredCollection.Clear();
        foreach( MyItem item in MasterCollection )
        {
            if( ( item.Color == Green && IsGreen ) || ( item.Color == Yellow && IsYellow ) || ( item.Color == Red && IsRed ) )
            {
                FilteredCollection.Add( item );
                /*
                   And do this for child items, etc -- you'll probably
                   have to rebuild the tree/MyItem's since some items
                   will not appear under their parents;
                   So this might look more like:
                FilteredCollection.Add( new MyItem()
                                        {
                                           Color = item.Color,
                                           Label = item.Label 
                                        } );
                */
            }
        }
    }
