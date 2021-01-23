     void listView1_ItemActivate(object sender, EventArgs e)
     {
        listViewValue = listView1.SelectedItems[0].Text; // Get the listViewItem value and save to public property
        this.Close(); // Close
     }
     public String listViewValue { get; set; } // public property to store the ListView value
