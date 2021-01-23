    foreach (var obj in listobject)
    {
        Item item = await client.GetItemAsync(auctionInfo);
        information.Add(new clsinform
        {
            param1 = item.Property
        });
    }
