        var names = (from autonames in lstDetails
                     where autonames.name.Contains(txtautosgn.Text.Trim())
                     select autonames.name).ToList();
        if (names.Count > 1)
        {
            lstnames.Items.Clear();
            lstnames.Visibility = Visibility.Visible;
            lstnames.ItemsSource = names;
            lstnames.SelectedIndex = 0;
        }
        else
        {
            lstnames.Visibility = Visibility.Collapsed;
        }
