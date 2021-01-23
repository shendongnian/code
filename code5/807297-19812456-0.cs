         public Customer Deserialize(string str)
        {
            **Customer customer = new Customer();**
            var strCustomer = str.Split(',');
            customer.Id = int.Parse(strCustomer[0]);
            customer.FirstName = strCustomer[1];
            customer.LastName = strCustomer[2];
            customer.Age = int.Parse(strCustomer[3]);
            customer.Country = strCustomer[4];
            return customer;
        }
