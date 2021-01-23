    var locations = from c in Customers
                    join ca in CustomerAddresses
                    on new { c.CustomerAddressId, 0 } 
                        equals new { ca.CustomerAddressId, ca.PrioritySeq }
                    select new Location
                    {
                        CustomerNumber = c.MasterCustomerId,
                        City = ca.City,
                        State = ca.State,
                        Country = ca.Country,
                        AddressLocCode = ca.AddressLocCode,
                        AddressStatus = ca.AddressStatus
                    };
