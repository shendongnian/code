    IEnumerable<object> GetGalleriesAndMedia(int eventId)
    {
        foreach (var gallery in from g in db.Galleries
                                where g.EventId == eventId
                                orderby g.SortOrder
                                select g)
        {
            yield return gallery;
            foreach (var media in gallery.Media.OrderBy(m => m.SortOrder))
                yield return media;
        }
    }
