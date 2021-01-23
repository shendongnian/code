    foreach (object o in list)
    {
        BlobProperties bp = o as BlobProperties;
        if (bp != null)
        {
            BlobProperties p = _Container.GetBlobProperties(bp.Name);
            var name = p.Name; // get the name
        }
    }
