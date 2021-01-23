    using (var db = new ModelContactContainer())
    using (var transaction = db.Database.BeginTransaction())
    {
        db.Contact.Add(customerViewModel.contact);
        db.SaveChanges();
        
        customerViewModel.customer.Contact = customerViewModel.contact; 
        db.Customer.Add(customerViewModel.customer);
        db.SaveChanges();
        transaction.Commit();
    }
