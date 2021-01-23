    if(txtCustomerId.Text.Length > 0)
    {
        int id;
        if(int.TryParse(txtCustomerId.Text, out id))
        {
           using (var ctx = new MyDbContext())
           {
                // get customer name by Id, for example:
               var name = ctx.Customers.Where(c => c.CustomerId == id)
                        .Select(c => c.CustomerName)
                        .FirstOrDefault();
               if (name != null) txtCustomerName.Text = name;
           }
        }
    }
