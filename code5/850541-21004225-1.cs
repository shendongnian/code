    public partial class ItemsControlSample2 : Window
    {
        public ItemsControlSample2()
        {
            InitializeComponent();
            //Make sure you change this path to a valid path in your PC where you have JPG files
            var path = @"F:\Media\Images\My Drums";
            var images = Directory.GetFiles(path,"*.jpg")
                                  .Select(x => new ImageViewModel()
                                               {
                                                   Path = x,
                                               });
            DataContext = images.ToList();
        }
    }
