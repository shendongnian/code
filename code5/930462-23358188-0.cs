        private void DataLoaded(object o, RestResponseEventArgs e)
        { 
          Dispatcher.BeginInvoke(() =>
          {
           int i = 0;
           List<Entry> entries = new List<Entry>();
           foreach (JObject current in e.JsonObject["entries"].Children())
           {
             Entry e = Entry.Parse(current);
             entries.Add(e);
           }
           this.MyListBox.ItemsSource = entries;
           this.ProgressBar.Visibility = Visibility.Collapsed;
    
       this.ProgressBar.IsIndeterminate = false;
      });    
    }
