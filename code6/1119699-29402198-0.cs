    [NotMapped]
    public Image GetLargeSizeImage
    {
        get
        {
            return this
                   .ImageSet.OrderBy( x => x.ImageSizeType.Order )
                   .Where( x => x.ImageSizeType.Key == ImageSizeType.Large )
                   .FirstOrDefault() ?? GetMediumSizeImage;
            }
        }
    }
    
    [NotMapped]
    public Image GetMediumSizeImage
    {
        get
        {
            return this
                   .ImageSet.OrderBy( x => x.ImageSizeType.Order )
                   .Where( x => x.ImageSizeType.Key == ImageSizeType.Medium)
                   .FirstOrDefault() ?? GetSmallSizeImage;
            }
        }
    }
