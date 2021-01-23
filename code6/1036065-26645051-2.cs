    public void AddInfo(object sender, RoutedEventArgs e)
    {
        // You need to reference a specific row of your ListBox control.
    
        // Make sure there is at least 1 item.
        if (ListData.Items.Count > 0)
        {
            // Get a reference to the first bound object (data that is bound to the text blocks).
            var item = (PhoneModel)ListData.Items[0];
    
        }
    }
