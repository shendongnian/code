    private void Get_Click(object sender, RoutedEventArgs e)
    {
        foreach (ListBoxItem lbi in listbox1.Items)
        {
            if (lbi.Content.ToString() == tb1.Text)    //new code
            {                                          //new code
                lbi.IsSelected = true;                 //new code
                break;                                 //new code
            }                                          //new code
        }
        int x = listbox1.SelectedIndex;
        listbox2.SelectedIndex = x;
        listbox3.SelectedIndex = x;
        ListBoxItem lb1 = (listbox1.SelectedItem as ListBoxItem);
        //tb1.Text = lb1.Content.ToString();           //updated code
        ListBoxItem lb2 = (listbox2.SelectedItem as ListBoxItem);
        tb2.Text = lb2.Content.ToString();
        ListBoxItem lb3 = (listbox3.SelectedItem as ListBoxItem);
        tb3.Text = lb3.Content.ToString();
    }
