    var blobChank = ... ;
    foreach (object o in blobChank)
    {
        BlobProperties bp = o as BlobProperties;
        if (bp != null)
        {
            BlobProperties p = _Container.GetBlobProperties(bp.Name);
            var name = p.Name; // get the name
        }
    }
