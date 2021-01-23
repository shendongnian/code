    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var str = new StringBuilder();
        foreach (ListBoxItem item in Lbox.Items)
        {
            if (item.IsSelected)
            {
                str.Append( item.Content + " ");
            }
        }
        MessageBox.Show(str.ToString());
    }
