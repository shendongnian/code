    private void Button_Click(object sender, RoutedEventArgs e)
    {
        StringBuilder str = new StringBuilder();
        foreach (ListBoxItem item in Lbox.Items)
        {
            if (item.IsSelected)
            {
                TextBlock t = item.Content as TextBlock;
                str.Append(t.Text + " ");
            }
        }
        MessageBox.Show(str.ToString());
    }
