    public CollectionViewSource ArtistList
    {
        get
        {
            if(_ArtistList == null)
            {
                var data = App.musicdata.Artists;
                var groups = data.ToAlphaGroups(x => x.name);
                _ArtistList = new CollectionViewSource();
                _ArtistList.Source = groups; //groups is the result of using my extension methods above
                _ArtistList.IsSourceGrouped = true;
            }
            return _ArtistList;
        }
    }
