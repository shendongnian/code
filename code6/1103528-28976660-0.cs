    if (this.CustomerId.HasValue)
    {
        var c = this.DataWorkspace.ApplicationData.Customers.Where(w => w.Id == this.CustomerId.Value).Single();
        this.Customer.Name = c.Name;
        this.Customer.AddressLine1 = c.AddressLine1;
    }
