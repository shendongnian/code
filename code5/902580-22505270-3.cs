    public string PhotoName { get; set; }
    public BitmapImage Photo { get; set; }
 
    public static List<PhotoItem> GetPhotos()
    {
        return new List<PhotoItem>()
        {
            new PhotoItem(){PhotoName="Image1",Photo = new BitmapImage(new Uri("/Images/Image1.jpg", UriKind.Relative))},
            new PhotoItem(){PhotoName="Image2",Photo = new BitmapImage(new Uri("/Images/Image2.jpg", UriKind.Relative))},
        };
    }
