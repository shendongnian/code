    private object _syncRoot = new Object();
    
    private async void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
      lock( _syncRoot) 
      {
        ListBox.Items.Clear();
        foreach (Item a in arr)
        {
           if(a.Title.Contains(SearchTextBox.Text))
           {
               ListBox.Items.Add(a);
           }
        }
      }
    }
