    private OrderHeader FindOrCreateOrder()
    {
        var UserName = this.User.Identity.Name;
        var user = UserManager.FindByName(UserName);
        if (user != null)
        {
            var customer = _context.Customers
                .Include(c => c.OrderHeaders.Select(o => o.OrderLineItems.Select(i => i.Product))).
                FirstOrDefault(c => c.UserId.Equals(user.Id));
    
            var order = customer.OrderHeaders
                .OrderBy(o => o.OrderDate)
                .LastOrDefault(o => o.Paid == false);
    
            if(order == null)
            {
                order = new OrderHeader();
                //var Customer = new Customer();
                order.Customer = customer;
                customer.OrderHeaders.Add(order);
                _context.SaveChanges();
            }
            return order;
        }
        else
        {
            // logic when user is null
        }
    }
