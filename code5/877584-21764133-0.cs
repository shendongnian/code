    if(txtCustomerId.Text.Length > 0)
    {
        int id;
        if(int.TryParse(txtCustomerId.Text, out id))
        {
           using (var ctx = new MMyDbContext())
           {
                // get customer name by Id, for example:
               var name = ctx.Customers.Where(c => c.CustomerId == id)
                        .Select(c => c.CustomerId)
                        .FirstOrDefault();
               if (name != null) txtCustomerName.Text = name;
           }
        }
    }
