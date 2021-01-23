     private void UpdateFeedList(string feedXML)
        {
            // Load the feed into a SyndicationFeed instance.
            StringReader stringReader = new StringReader(feedXML);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            SyndicationFeed feed = SyndicationFeed.Load(xmlReader);
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                // Bind the list of SyndicationItems to our ListBox.
                feedListBox.ItemsSource = feed.Items;
                loadFeedButton.Content = "Refresh Feed";
                feedListBox.SelectionMode = SelectionMode.Multiple;
                feedListBox.SelectAll();
            });
        }
       
        // The SelectionChanged handler for the feed items 
       
        
        private void feedListBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            
            if (listBox != null && listBox.SelectedItem != null)
            {
                // Get  the SyndicationItem that was tapped.
                SyndicationItem sItem = (SyndicationItem)listBox.SelectedItem;
                synth.SpeakTextAsync(sItem.Title.Text);
                if (feedListBox.SelectedIndex < feedListBox.Items.Count - 1)
                {
                    feedListBox.SelectedIndex = feedListBox.SelectedIndex + 1;
                }     
                
