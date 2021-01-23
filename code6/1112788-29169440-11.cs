    var adrsQuery = (from a in this.Context.Addresses
            where myList.Contains(a.Address_K)
            select new AlternateAddressesDB()
            {
                Line1 = a.AddressLine1,
                Line2 = a.AddressLine2,
                City = a.City,
                State = a.State,
                ZipCode = a.ZipCode
            })
            .AsEnumerable() // From here the query is executed "locally"
            .Select(a => new AlternateAddressesDB()
            {
                Line1 = GetAddressLine1(a.Line1),
                a.Line2,
                a.City,
                a.State,
                a.ZipCode
            })
            .ToList();
