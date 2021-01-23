    private void photoChooserTask_Completed(object sender, PhotoResult e)
        {
            if (e.ChosenPhoto != null)
            {
                BitmapImage image = new BitmapImage();
                image.SetSource(e.ChosenPhoto);
                this.img.Source = image;
     PhoneApplicationService.Current.State["Image"] = image;
            }
        }
    //On second page
    //I assume you want to image on page load
    protected override void OnNavigatedTo(NavigationEventArgs e)
        {
          BitmapImage image = new BitmapImage();
         image  =(BitmapImage )PhoneApplicationService.Current.State["Image"]
         PhoneApplicationService.Current.State.Remove("Image");
         this.img.Source = image;
        }
