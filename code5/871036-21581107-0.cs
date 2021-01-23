    foreach (Item item in lstItemsAdded.Items)
    {
        var newObject = new PersonItemObject()
        {
            FirstName = txtFirstName.Text;
            LastName = txtLastName.Text;
            ID = txtID.Text;
            Email = txtEmail.Text;
            Age = Convert.ToInt32(txtAge.Text);
            Item.ItemCode = item.ItemCode;
            Item.ItemDescription = item.ItemDescription;
            Item.ItemName = item.ItemName;
            Item.ItemPrice = item.ItemPrice;
        }
        PersonItemsList.Add(newObject);
    }
