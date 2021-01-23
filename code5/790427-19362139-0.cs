    txtcontent.AddHandler(TappedEvent, new TappedEventHandler(txtcontent_Tapped), true);
    
      void txtcontent_Tapped(object sender, TappedRoutedEventArgs e)
            {
                System.Diagnostics.Debug.WriteLine("Tested!!");
            }
