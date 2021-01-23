    static void List_SelectionChanged(ListBox lst, TextBlock tb)
    {
        MessageBox.Show("clist   _SelectionChanged1");
        tb.Text = lst.SelectedItem; // or tb.Text=lst[lst.SelectedIndex];
    }
