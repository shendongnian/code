        try
        {
            using (var ctx = new OrdersDbContext())
            {
                var agg = ctx.Customers.First(x => x.LiveOrder.Id == parentId);
                var pos = agg.LiveOrder.Single(o => o.Id == childId);
                pos.Price = 5;
                ctx.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
