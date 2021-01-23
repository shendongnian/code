    private void CheckBox_Checked(object sender, EventArgs e)
    {
        _list.ItemsSource = _allUris;
    }
    private void CheckBox_UnChecked(object sender, EventArgs e)
    {
        _list.ItemsSource = _allUris.GroupBy(u => u.UriString)
                                    .Select(gr => gr.First());
    }
