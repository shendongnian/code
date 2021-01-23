    private Image GetMeTheImage(string targetSizeType) 
    {
        return this.ImageSet
            .Where(i => i.ImageSizeType.Key != ImageSizeType.Original)
            .OrderByDescending(i => i.ImageSizeType.Key == targetSizeType)
            .ThenBy(i => i.ImageSizeType.Order)
            .FirstOrDefault();
    }
    public Image GetLargeSizeImage
    {
        get
        {
            // Given OPs example table where Large is missing, 
            // this should return the ExtraLarge image.
            return GetMeTheImage(ImageSizeType.Large);
            
        }
    }
