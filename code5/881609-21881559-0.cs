    public static CustomerViewModel ToViewModel(this Customer cust)
            {
                return new CustomerViewModel()
                    {
                        CompanyName = cust.CompanyName,
                        CustomerType = cust.CustomerType,
                        ContactName = cust.CustomerContacts.First().ContactName,
                        ContactTel = cust.CustomerContacts.First().ContactTel
                    };
            }
