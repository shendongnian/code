    foreach (var address in Addresses)
    {
        if(!address.IsDefault)
        {
            AddressList.Add(address);
        }
    }
    AddressList.InsertItem(0, Address.Select(x => x.IsDefault));
