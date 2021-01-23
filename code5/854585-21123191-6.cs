    public MyUserControlVieWModel ViewModel
    {
        get
        {
            return this.DataContext as MyUserControlVieWModel;
        }
    }
    public void ImageLoaded( object sender, RoutedEventArgs args )
    {
        // call down to your view model
        if( ViewModel != null )
        {
            ViewModel.ImageLoadedHandler( );
        }
    }
