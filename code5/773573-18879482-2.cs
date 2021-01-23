    foreach (var address in Addresses)
    {
        if(!address.IsDefault)
        {
            AddressList.Add(address);
        }
    }
    AddressList.InsertItem(0, Addresses.Where(x => x.IsDefault).ToList()[0]);
