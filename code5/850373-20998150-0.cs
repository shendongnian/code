    private void listView1_DoubleClick(object sender, EventArgs e)
    {
        bool add = true;
        string selected = listView1.Items[listView1.FocusedItem.Index];
        foreach(ListViewItem item in listView2.Items)
            if (selected.SubItems[0].Text == item.SubItems[0].Text)
            {
                add = false;
                break;
            }
        if(add)
            listView2.Items.Add(selected);
        else
            MessageBox.Show("Student is already present in the list.","Cannot add to list",MessageBoxButtons.OK,MessageBoxIcon.Hand);
    }
