              var customersList = (from c in context.Customers
                                    where c.IsDeleted == false
                                    select new
                                    {
                                        Name = c.FirstName + " " + c.LastName,
                                        c.CustomerId
                                    }).ToList();
        
         cmbCustomer.ItemsSource = customersList;
         cmbCustomer.DisplayMemberPath = "Name";
         cmbCustomer.SelectedValuePath = "CustomerId";
