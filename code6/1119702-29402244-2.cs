    private Image GetMeTheImage(string targetSizeType) 
    {
        return this.ImageSet
            .OrderByDescending(i => i.ImageSizeType.Key == targetSizeType)
            .ThenBy(i => i.ImageSizeType.Order)
            .FirstOrDefault();
    }
    public Image GetLargeSizeImage
    {
        get
        {
            return GetMeTheImage(ImageSizeType.Large);
            // or if you were targeting the original
            // return GetMeTheImage(ImageSizeType.Original);
        }
    }
