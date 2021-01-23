    foreach (var phone in vendor.Vendors.SelectMany(item => item.Phones))
                {
                    phone.Types = new List<NumberTypeClass>
                    {
                        new NumberTypeClass{Id = 0, NumberType = "Mobile"},
                        new NumberTypeClass{Id = 0, NumberType = "Work"},
                        new NumberTypeClass{Id = 0, NumberType = "Home"}
                    };
                }
