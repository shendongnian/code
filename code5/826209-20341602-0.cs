    private void txt_Search_TextChanged(object sender, System.EventArgs e)
    {
        if (txt_Search.Text != "") {
            for(int i = listView1.Items.Count - 1; i >= 0; i--) {
                var item = listView1.Items[i];
                if (item.Text.ToLower().Contains(txt_Search.Text.ToLower())) {
                    item.BackColor = SystemColors.Highlight;
                    item.ForeColor = SystemColors.HighlightText;
                }
                else {
                    listView1.Items.Remove(item);
                }
            }
            if (listView1.SelectedItems.Count == 1) {
                listView1.Focus();
            }
        }
        else   
            LoadContacts();
            RefreshAll();
        }
    }
