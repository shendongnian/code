    public class ImageContainer
    {
        private List<Image> images;
        public List<Image> Images { 
            if (null == images)
                images = ImageProvider.GetImages();
            
            return images;
        }
        ... 
        < constructor here, etc. >
    }
