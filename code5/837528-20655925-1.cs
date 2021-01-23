    List<BitmapImage> ListImages = new List<BitmapImage>();
     DispatcherTimer Timer = new DispatcherTimer();
    int SlideCount=0;
    void Page1_Loaded(object sender, RoutedEventArgs e)
    {
      LoadImages();
      DisTimer.Tick += DisTimer_Tick;
      DisTimer.Interval = new TimeSpan(0, 0, 1);
      DisTimer.Start();
    }
    private void LoadImages()
    {
      ListImages.Add( new BitmapImage(new Uri("/Your project name;component/Image/aaa.jpg", UriKind.Relative))); 
     ListImages.Add( new BitmapImage(new Uri("/Your project name;component/Image/bbb.jpg", UriKind.Relative))); 
     ListImages.Add( new BitmapImage(new Uri("/Your project name;component/Image/ccc.jpg", UriKind.Relative))); 
     ListImages.Add( new BitmapImage(new Uri("/Your project name;component/Image/ddd.jpg", UriKind.Relative))); 
    
    ListImages.ItemsSource =ListImages;
    }
     void DisTimer_Tick(object sender, EventArgs e)
            {
    if(SlideCount<=3)
    {
    listControlImage.SelectedIndex = SlideCount;
    SlideCount++;
    }
    else
       SlideCount=0;
            }
 
   
     private void listControlImage_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
                {
    if(listControlImage.SelectedIndex ==-1)
    return;
        //Your Navigation code
                }
