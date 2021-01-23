    private void BuildControl(PhotoThumbnail pp)
    {
        switch(pp.NName)
        {
            case "flip":
                // unhook event
                lp.SelectionChanged -= lp_SelectionChanged;
                 
                List<ListPickerItem> l = new List<ListPickerItem>();                    
                l.Add(new ListPickerItem { Name = "Flip_Vertical", Content = AppResources.App_Flip_Vertical });
                l.Add(new ListPickerItem { Name = "Flip_Horizontal", Content = AppResources.App_Flip_Horizontal });
                l.Add(new ListPickerItem { Name = "Flip_Both", Content = AppResources.App_Flip_Both });
                lp.ItemsSource = l;  //Code execution jumps from here to ValueChanged event immediately                  
                lp.Visibility = Visibility.Visible;
                lp.SelectedIndex = Settings.Flip.Value - 1;
                // after setting the index, rehook the event
                lp.SelectionChanged += lp_SelectionChanged;
                break;
        ..
        }
    }
