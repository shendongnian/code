    private bool _alreadyChanging = false;
    
    private void txtLocation_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (!_alreadyChanging)
        {
            _alreadyChanging = true;
            MessageBox.Show("Must have a repair report.", "No Report");
            txtLocation.SelectedItem = MAIN_BACKGROUND.UserName;
            _alreadyChanging = false;
        }
    }
