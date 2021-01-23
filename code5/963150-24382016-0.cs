    private void OnTextChanged(object sender, TextChangedEventArgs args)
    {
        var textBox = (sender as TextBox);
        if (textBox != null)
        {
            PopulateObservableCollection();
        }
    }
    private void PopulateObservableCollection()
    {
        // Populate ObservableCollection
    }
