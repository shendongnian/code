    var contentPages = Model.ContentPages.ToList();
    for (int i = 0; i < contentPages.Count(); i++)
    {
        <ul>
            if (contentPages.Any(m => m.Url == contentPages[i].ParentReference))
            {
                ...
