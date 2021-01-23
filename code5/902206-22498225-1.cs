    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        { 
            try
            {
            string photo;
            string name;
            string age;
            string breed;
            string price;
    
                if (NavigationContext.QueryString.TryGetValue("photo", out photo))
                {
                    imgPhotoHolder.Source = null;
    
                    BitmapImage myImage = new BitmapImage
                    (new Uri(photo, UriKind.Relative));
    
                    imgPhotoHolder.Source = myImage;
                }
                if (NavigationContext.QueryString.TryGetValue("name", out name))
                {
                    nameTxtBlock.Text = name;
                }
                if(NavigationContext.QueryString.TryGetValue("age", out age))
                {
                    ageTxtBlock.Text = age;
                }
                if(NavigationContext.QueryString.TryGetValue("breed", out breed))
                {
                    breedTxtBlock.Text = breed;
                }
                if (NavigationContext.QueryString.TryGetValue("price", out price))
                {
                    priceTxtBlock.Text = price;
                }
                }catch(Exception ex)
                {
                }
         }
