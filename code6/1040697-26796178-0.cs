        // Assuming that this is your control
        ListView yourControl = new ListView();
        yourControl.Items.Add(new ListViewItem() { Content = "Apple" });
        yourControl.Items.Add(new ListViewItem() { Content = "Ball" });
        yourControl.Items.Add(new ListViewItem() { Content = "Cat" });
        yourControl.Items.Add(new ListViewItem() { Content = "Dog" });
        // get your index
        var newList = yourControl.Items.OfType<ListViewItem>().Select(Item => Item.Content.ToString()).ToList();
        int catIndex = newList.IndexOf("Cat"); // <-- your index
