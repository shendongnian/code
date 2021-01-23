    private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {
        foreach (int item in listView1.SelectedIndices)
        {
            if (listView1.Items[item].Selected)
            {
                listView2.Items[item].Selected = true;
                listView2.Select();
            }
        }
    }
