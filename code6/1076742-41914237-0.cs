        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            int temp = 0;
            listView1.ItemSelectionChanged -= listView1_ItemSelectionChanged;
            if (!e.IsSelected)
            {
                temp = e.ItemIndex;
                listView1.Items[temp].Selected = true;
                listView1.Items[temp].Focused = true;
            }
            else
            {
                for (int y = listView1.Items.Count - 1; y >= 0; y--)
                {
                    listView1.Items[y].Selected = false;
                }
                listView1.Items[e.ItemIndex].Selected = true;
            }
            listView1.ItemSelectionChanged += listView1_ItemSelectionChanged;
        }
