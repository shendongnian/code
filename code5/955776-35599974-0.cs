    private void MyGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems != null)
            {
                foreach (var item in e.AddedItems.Cast<ViewModel>())
                {
                    System.Diagnostics.Debug.WriteLine("** Item {0} is added to selection.", item.Id);
    
                    if (!item.IsSelected)
                    {
                        // if bound data item still isn't selected, fix this
                        item.IsSelected = false;
                    }
                }
            }
            if (e.RemovedItems != null)
            {
                foreach (var item in e.RemovedItems.Cast<ViewModel>())
                {
                    System.Diagnostics.Debug.WriteLine("** Item {0} is removed from selection.", item.Id);
    
                    if (item.IsSelected)
                    {
                        // if bound data item still is selected, fix this
                        item.IsSelected = false;
                    }
                }
            }
    
            e.Handled = true;
        }
