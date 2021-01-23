    string[] newNames = ServiceLayerSplitCommaSeparatedIntoArray(addressObj);
    var entity = dbContext.Set<Address>().Find(addressId);
    entity.Names.Clear();
    foreach (var newName in newNames)
        entity.Names.Add(new Name {
            Value = newName,
        });
    dbContext.SaveChanges();
