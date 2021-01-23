    string[] newNames = ServiceLayerSplitCommaSeparatedIntoArray(addressObj);
    var entity = dbContext.Set<Address>().Find(addressId);
    entity.Names.Clear();
    foreach (var newName in newNames)
        entity.Names.Add(new AddressName {
            Value = newName,
        });
    dbContext.SaveChanges();
