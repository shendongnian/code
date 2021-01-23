    private void Continue(object sender, RoutedEventArgs e)
    {
        if(selection != null)
        {
            if(selection == "English")
                this.Frame.Navigate(typeof(EnglishPage));
            else if(selection == "Hindi")
                this.Frame.Navigate(typeof(HindiPage));
             //and so on
         }
     }
