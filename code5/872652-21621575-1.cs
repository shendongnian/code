    protected void imgbtnMoveRightListBox_Click(object sender, EventArgs e)
    {
        lbltxt.Visible = false;
        if (ListBox1.SelectedIndex >= 0) // in this we are checking whether a single item is clicked.
        {
            for (int i = 0; i < ListBox1.Items.Count; i++)  // we are looping through the list box items
            {
                if (ListBox1.Items[i].Selected) // finding the selected items
                {
                    if (!arraylist1.Contains(ListBox1.Items[i]))
                    {
                        arraylist1.Add(ListBox1.Items[i]); //if found then adding those items to the array list
                    }
                }
            }
            for (int i = 0; i < arraylist1.Count; i++)
            {
                if (!ListBox2.Items.Contains(((ListItem)arraylist1[i])))
                {
                    ListBox2.Items.Add(((ListItem)arraylist1[i])); // we are adding the array elements to the second list box 
                }
                ListBox1.Items.Remove(((ListItem)arraylist1[i]));
            }
            ListBox2.SelectedIndex = -1; 
        }
        else
        {
            lbltxt.Visible = true;
            lbltxt.Text = "Please select atleast one in Listbox1 to move";
        }
    }
