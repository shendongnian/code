    private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            listView1.ItemSelectionChanged -= listView1_ItemSelectionChanged;
            if (!e.IsSelected)
            {
                listView1.Items[0].Selected = true;
                listView1.Items[0].Focused = true;
            }
            else
            {
                listView1.Items[0].Selected = false;
                listView1.Items[e.ItemIndex].Selected = true;
            }
            listView1.ItemSelectionChanged += listView1_ItemSelectionChanged;
        }
