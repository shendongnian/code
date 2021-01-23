    // Check if your list has items with same contacts
    if (!query.Any(a => a.Contact1.Equals(a.Contact2)))
    {
        return query;
    }
    // Else, create two new lists
    var itemsWithSameContacts = query.Where(a => a.Contact1.Equals(a.Contact2));
    var firstList = itemsWithSameContacts.Select(a => new AddressLabels
    {
        Id = a.Id,
        Name = a.Name,
        Address1 = a.Address1,
        Address2 = a.Address2,
        ZipCode = a.ZipCode,
        City = a.City,
        Country = a.Country,
        Contact1 = a.Contact1,
    }).ToList();
    var secondList = itemsWithSameContacts.Select(a => new AddressLabels
    {
        Id = a.Id,
        Name = a.Name,
        Address1 = a.Address1,
        Address2 = a.Address2,
        ZipCode = a.ZipCode,
        City = a.City,
        Country = a.Country,
        Contact2 = a.Contact2,
    }).ToList();
    // If you want these lists also to have contacts 
    // which don't have same contacts, then you can also
    var itemsWithNotSameContacts = query.Where(a => !a.Contact1.Equals(a.Contact2));
    firstList.AddRange(itemsWithNotSameContacts);
    secondList.AddRange(itemsWithNotSameContacts);
