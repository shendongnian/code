    public void SomeMethod(int orderId)
    {
       using (var db = new MyDbContext())
       {
          var order = db.Orders.FirstOrDefault(x=>x.Id==orderId);
          if (order!=null) //order.TaxisId = 1
          {        
            if (SettingsModel.AutoSetToTheNextTaxi)
            {
              order.TaxisId = 2;
            }
            else
            {
              order.TaxisId = null;
            }
            db.SaveChanges(); 
          }
       }
    }
