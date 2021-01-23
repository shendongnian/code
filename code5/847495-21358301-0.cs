    // set outside of the other two functions so it will be global
    string publishingpoint_sunday = "";
    public async void Rebroadcast()
    {
        publishingpoint_sunday = rootObject.sunday_publishingpoint_smoothstreaming;
        HyperlinkButton sunday_title = new HyperlinkButton();
        sunday_title.Content = "Sunday (" + sunday.ToUpper() + ")";
        sunday_title.Click += sunday_link_Click;
    }
    private void sunday_link_Click(object sender, RoutedEventArgs e)
    {
        this.Frame.Navigate(typeof(Player), publishingpoint_sunday);
    }
