    private int PopupID;
    private bool IsPopupActive;
    private void RadioButton_Click(object sender, RoutedEventArgs e)
    {
        RadioButton rb = (RadioButton)sender;
        string s = (string)rb.Content;
        int id = int.Parse(s);
        if (PopupID == id && IsPopupActive == true)
        {
            foreach (RadioButton rbb in PopupGrid.Children.OfType<RadioButton>())
                rbb.SetValue(RadioButton.IsCheckedProperty, false);
            IsPopupActive = false;
        }
        else if (PopupID != id || IsPopupActive == false)
        {
            foreach (RadioButton rbb in PopupGrid.Children.OfType<RadioButton>()
                    .Where(x => x != rb))
                rbb.SetValue(RadioButton.IsCheckedProperty, false);
            IsPopupActive = true;
            PopupID = id;
        }
    }
