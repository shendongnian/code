           else if (Result == "Customer")
            {
                while (dr.Read())
                {
                    clsCustomer.CustomerId = (int)dr["CustomerId"];
                    clsCustomer.CustomerName = (string)dr["CustomerName"];
                    clsCustomer.CustomerEmail = (string)dr["CustomerEmail"];
                    clsCustomer.CustomerMobile = (string)dr["CustomerMobile"];
                }
    
                return clsCustomer;
            }
    
                return Result;
            }
