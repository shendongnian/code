    // a property in your class
    public Uri FirstImage
    {
       get
       {
            return new Uri(ImagePathList.FirstOrDefault(), UriKind.Absolute);
       }
    }
