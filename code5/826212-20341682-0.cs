    // declare lastSearchLength as a int outside of your TextChanged delegate
    if (!String.IsNullOrEmpty(txt_Search.Text) && txt_Search.Text.Length > lastSearchLength)
    {
        foreach (ListViewItem item in listView1.Items)
        {
            if (item.Text.ToLower().Contains(txt_Search.Text.ToLower()))
            {
                item.Selected = true;
            }
            else
            {
                listView1.Items.Remove(item);
            }
            }
            if (listView1.SelectedItems.Count == 1)
            {
                listView1.Focus();
            }
            lastSearchLength = txt_Search.Text.Length;
        }
        else 
        { 
            LoadContacts();
            RefreshAll();
        }
    }
  
