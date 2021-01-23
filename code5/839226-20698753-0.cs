    private async void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
      if( string.IsNullOrEmpty( a.Title ) == false )
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
