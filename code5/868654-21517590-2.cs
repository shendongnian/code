    public class ImageProcessor
    {
        < constructor here, etc. >
 
        ... 
        public void UseImages()
        {
            List<Image> images = ImageProvider.GetImages();
            images.ForEach(i => [ do something with i ]);
        }
    }
