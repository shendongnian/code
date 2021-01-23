    public Customer FindCustomer(int id)
    {
        Customer find = new Customer(id);
        for (int i = 0; i < customerList.Count; i++)
            if (customerList[i].Equals(find))
                return customerList[i];
       return null;
    }
