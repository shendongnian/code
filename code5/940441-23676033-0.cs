    public static void SaveOrder()
        {
            using (EposWebOrderEntities Ctx = new EposWebOrderEntities())
            {
                 Ctx.Entry<Order>(order).State = EntityState.Added;
                 Ctx.Entry<Dressing>(dressing).State = EntityState.Added;
                 Ctx.SaveChanges();
    
            }
        }
