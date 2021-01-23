    private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      ListView control = (ListView)sender;
      var item = (ListViewItem)control.SelectedItem;
      textBox1.Text = item.Content.ToString();
    }
