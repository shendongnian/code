    public class MainForm : Form
    {
        private readonly EventAggregator eventAggregator;
        private readonly VideoProcessing videoProcessing;
    
        public MainForm()
        {
            this.eventAggregator = new EventAggregator();
            this.eventAggregator.Subscribe<NewBitmapEvent>(HandleNewBitMap);
            this.videoProcessing = new VideoProcessing(this.eventAggregator);
        }
    
        private void HandleNewBitmap(Bitmap args)
        {
            // Do something
        }
    }
    
    public class VideoProcessing
    {
        private readonly EventAggregator eventAggregator;
    
        private readonly ImageProcessing imageProcessing;
    
        public VideoProcessing(EventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.imageProcessing = new ImageProcessing(this.eventAggregator);
        }
    }
    
    
    public class ImageProcessing
    {
        private readonly EventAggregator eventAggregator;
    
        public ImageProcessing(EventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.eventAggregator.Publish<NewBitmapEvent>(new Bitmap(...));
        }
    }
