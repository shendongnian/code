    private void listView1_DoubleClick(object sender, EventArgs e)
    {
        bool test = true;
        var selectedItem = listView1.SelectedItems[0];
        foreach(var item in listview2.Items)
        {
             string listview2Text = item.SubItems[0].Text;
             string listview1Text = selectedItem.SubItems[0].Text;
             if (listview2Text.Trim() == listview1Text.Trim())
             {
                test = false;
             }
        }
        if (test == true)
        {
            //I am not sure exactly what you're trying to do if the test is true but I think you're trying to do this
            listView2.Items.Add(selectedItem);
        } 
        else
        {
            MessageBox.Show("Student is already present in the list.","Cannot add to list",MessageBoxButtons.OK,MessageBoxIcon.Hand);
        }
    }
