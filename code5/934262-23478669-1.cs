    private void Control_OnPreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        var toggleButtton = sender as ToggleButton;
        if (toggleButtton != null)
        {
            if (toggleButtton.IsChecked.HasValue)
            {
                if (toggleButtton.IsChecked.Value)
                {
                    // Checked
                }
                else
                {
                    // Unchecked
                    
                    // this will re-check the button if double-click unchecks it
                    //
                    toggleButtton.IsChecked = true;
                    toggleButtton.Focus();
                }
            }
        }
    }
