    private void NavigateKing(object sender, SelectionChangedEventArgs e)
    {
        ComboBoxItem cbi = (ComboBoxItem)((sender as ComboBox).SelectedItem);
        string navigatingURI = cbi.Content.ToString();
        this.Frame.Navigate(Type.GetType(this.GetType().Namespace + "." + cbi.Tag.ToString()));
    }
