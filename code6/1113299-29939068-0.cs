    public bool UpdateOrder(Order order)
        {
    using(var db = DB){
                db.Orders.Attach(order);
                var entry = db.Entry(order);
                entry.Property(x => x.OrderStatusId).IsModified = true; //Exception thrown
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    logger.Fatal(e);
                }
                return true;
    }
            }
