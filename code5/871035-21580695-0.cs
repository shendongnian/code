    foreach (Item item in lstItemsAdded.Items)
    {
        var newObject = new PersonItemObject();
        newObject.FirstName = txtFirstName.Text;
        newObject.LastName = txtLastName.Text;
        newObject.ID = txtID.Text;
        newObject.Email = txtEmail.Text;
        newObject.Age = Convert.ToInt32(txtAge.Text);
        newObject.Item.ItemCode = item.ItemCode;
        newObject.Item.ItemDescription = item.ItemDescription;
        newObject.Item.ItemName = item.ItemName;
        newObject.Item.ItemPrice = item.ItemPrice;
        PersonItemsList.Add(newObject);
    }
