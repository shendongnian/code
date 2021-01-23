    var preExistentIds = (from x in context.CustomerAddresses select x.CustomerAddressID).ToList();
    foreach (var deleted in preExistentIds.Where(x => !newCustomerAddr.Exists(y => y.CustomerAddressID == x)))
    {
        var entity = new CustomerAddresses { CustomerAddressID = deleted.CustomerAddressID };
        context.CustomerAddresses.Attach(entity);
        context.Entry(entity).State = EntityState.Deleted;
    }
    foreach(var item in newCustomerAddr){
        var entity = new CustomerAddresses { CustomerAddressID = item.CustomerAddressID };
        context.CustomerAddresses.Attach(entity);
        entity.Fields = item.Field;
        [..]
        context.Entry(entity).State = item.CustomerAddressID == 0? EntityState.Added : EntityState.Modified;
    }
    db.SaveChanges();
