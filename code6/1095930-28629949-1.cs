     // subquery returning the ALBUM ID
     var sq = QueryOver.Of<Image>()
          .Where(i => i.NumID == ImageID) //The ImageID is for example 1026
          .Select(i => i.Album.Id);       // here we return the Album.ID (column AlbumID)
     // just Albums with searched Image
     var query = QueryOver.Of<Album>()
                .WithSubquery
                   .WhereProperty(a => a.Id)
                   .In(sq) 
                ...
                .List<Album>();
