    void _placeTypes_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if(e.OldItems!=null)
            {
                placechange = true;
            }
        }
