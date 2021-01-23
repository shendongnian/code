    private void ListBox_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        Text = SelectedSuggestion;
        if (SuggestionSelected != null) SuggestionSelected(this, new EventArgs());
        Focus();
        CaretIndex = Text.Length;
        IsPopupOpen = false; // <<< Here is the line that closes the Popup
    }
