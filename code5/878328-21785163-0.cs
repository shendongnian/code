    List = customers.List.Select(c => new CustomerServiceModel
                            {
                                Id = c.Id,
                                ContractorId = c.ContractorId,
                                CompanyName = c.CompanyName,
                                Active = c.Active,
                                Address = new Address
                                {
                                    Address1 = c.Address1,
                                    Address2 = c.Address2,
                                    Address3 = c.Address3,
                                    Address4 = c.Address4,
                                },
                                CustomerContacts = condition ?
                                    c.CustomersContacts.Select(a => new ContactServiceModel
                                    {
                                        Name = a.Name,
                                        Telephone = a.Telephone      
                                    }).Where(e => e.IsDefault)
                                    :null
                            }).ToList()
