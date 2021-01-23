    public class FlipBookViewModel
    {
        public List<ImageViewModel> FlipBookImages { get; private set; }
        
        public FlipBookViewModel(string[] imagePaths)
        {
            FlipBookImages = imagePaths.Select(imagePath => new ImageViewModel 
               { ImagePath = imagePath }
            ).ToList();
        }
    }
