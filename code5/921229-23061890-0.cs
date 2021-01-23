     public class PhotoItem
        {
            public string Name { get; set; }
            public BitmapImage Photo { get; set; }
    
            public static List<PhotoItem> getPhotos()
            {
                PhotoItem one = new PhotoItem();
                one.Photo = new BitmapImage(new Uri("",UriKind.Relative));
                one.Name = "Image1";
    
                PhotoItem two = new PhotoItem();
                two.Photo = new BitmapImage(new Uri("", UriKind.Relative));
                two.Name = "Image1";
    
                List<PhotoItem> Photos = new List<PhotoItem>();
                Photos.Add(one);
                return Photos;
            }
