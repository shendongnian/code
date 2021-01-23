    for (int i = 0; i < VehicleListBox.SelectedItems.Count; i++)
    {
        var item = (string)VehicleListBox.SelectedItems[i];
        VehicleListBox.Items.Remove(item);
        // assuming your company class has only a Name and ID...
        string name = ...  // parse name from item
        int id = ...       // parse id from item
        vehicles.Remove(vehicles.Single(x => x.Name == name && x.ID == id));
    }
