      if (listView1.SelectedItems.Count > 0)
            {
                object lst = listView1.SelectedItems[0].Clone();
                listView1.Items.RemoveAt(listView1.SelectedItems[0].Index);
                listView2.Items.Add((ListViewItem)lst);
    
                MessageBox.Show("Check OUT Complete");
    
            }
            else
                MessageBox.Show("No item selected!");
