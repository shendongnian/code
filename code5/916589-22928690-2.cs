     public void RemoveCustomer(int customerId)
     {
          using(var context = new MyDbContext())
          {
              var customer = context.Customers.SingleOrDefault(c => c.Id == customerId); 
              if (customer==null) throw new BusinessException("Customer does not exist");
              context.Customers.Remove(customer);    
              context.SaveChanges();
          }
     }
