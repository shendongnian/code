    IEnumerable<object> GetGalleriesAndMedia(int eventId)
    {
        var eventGalleries = (from g in db.Galleries
                             where g.EventId == eventId
                             orderby g.SortOrder
                             select g).ToList();
        var eventGalleryIds = eventGalleries.Select(x => x.GalleryId).ToList();
        var eventMedia = (from m in db.Media
                          where eventGalleryIds.Contains(m.GalleryId)                          
                          orderby m.SortOrder ascending 
                          select m).ToLookup(x => x.GalleryId);
        foreach (var gallery in eventGalleries)
        {
            yield return gallery;
            foreach (var media in eventMedia[gallery.GalleryId].OrderBy(m => m.SortOrder))
                yield return media;
        }
    }
