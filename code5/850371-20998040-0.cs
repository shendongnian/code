    private void listView1_DoubleClick(object sender, EventArgs e)
    {
        // Get the value of the selected item
        string theItem = listView1.SelectedItems[0];
    
        // Add to second list if it's not already in there
        if(!listView2.Items.Contains(theItem))
        {
            listView2.Items.Add(theItem);
        }
        else
        {
            MessageBox.Show("Student is already present in the list.","Cannot add to list",MessageBoxButtons.OK,MessageBoxIcon.Hand);
        }
    }
