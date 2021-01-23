    void addItem (object sender, EventArgs e) {
        // first create the new item!
        ListViewItem item = new ListViewItem();
        // add the properties..
        item.Content = "Hi, my name is Slim Shady!";
        if(messageBy == "user") {
            // if message is by user, align it to right
            item.HorizontalAlignment = HorizontalAlignment.Left;
        } else {
            // if message is by network (friend), align it to left
            item.HorizontalAlignment = HorizontalAlignment.Right;
        }
        // now add the item to the listbox
        chatList.Items.Add(item); // done! :-)
    }
