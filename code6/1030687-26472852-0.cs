              customersList  = from c in context
                   where c.IsDeleted == false
                   order by x.CustomerId
                   select new {
                Name = x.FirstName + " " + x.LastName,
                x.CustomerId
                };
        
         cmbCustomer.ItemsSource = customersList;
         cmbCustomer.DisplayMemberPath = "Name";
         cmbToStation.SelectedValuePath = "CustomerId";
