    if (isIpnValidated == true)
    {
        using (WebApplication1Entities db = new WebApplication1Entities())
        {
            if (db.Orderss.Any(o => o.Transaction == txnId)) return;
    
            Orders order = new Orders();
            order.UserId = userId;
            order.Date = System.DateTime.Now;
            order.Transaction = txnId;
            order.Amount = Convert.ToDecimal(mcGross);
            order.Email = payerEmail;
            order.Country = residenceCountry;
    
            db.Orderss.Add(order);
            db.SaveChanges();
        }
    }
