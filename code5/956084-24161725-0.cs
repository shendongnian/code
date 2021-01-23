     foreach (var customer in response)
        {
            if (!customer.PersonType.Equals(2))
            {
        	    var c =customer.ToSingleCustomerHead();
                
        		if (customer.Companies !=null && customer.Companies.FirstOrDefaultOrDefault() != null)
        			c.Email = companyResult.StandardEMail;
        		
        		list.Add(c);
            }
        }
