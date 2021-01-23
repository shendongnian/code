    public class ViewModel
  
      {
            private readonly ObservableCollection<Data> images = new ObservableCollection<Data>();
            public ObservableCollection<Data> Images
            {
                get { return images; }
            }
    
            public ViewModel()
            {
                Images.Add(new Data
                {
                    Image = new BitmapImage(new Uri("ms-appx:///../Assets/StoreLogo.scale-100.png")),
                    Name = "Image1",
                    xIndex = 50,
                    yIndex = 50
                });
    
                Images.Add(new Data
                {
                    Image = new BitmapImage(new Uri("ms-appx:///../Assets/SmallLogo.scale-100.png")),
                    Name = "Image2",
                    xIndex = 250,
                    yIndex = 250
                });
    
                Images.Add(new Data
                {
                    Image = new BitmapImage(new Uri("ms-appx:///../Assets/SplashScreen.scale-100.png")),
                    Name = "Image3",
                    xIndex = 500,
                    yIndex = 500
                });
            }
        }
    
