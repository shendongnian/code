    var locations = from c in Customers
                    join ca in CustomerAddresses
                    on c.CustomerAddressId equals ca.CustomerAddressId
                    select new Location
                    {
                        CustomerNumber = c.MasterCustomerId,
                        City = ca.City,
                        State = ca.State,
                        Country = ca.Country,
                        AddressLocCode = ca.AddressLocCode,
                        AddressStatus = ca.AddressStatus
                    };
