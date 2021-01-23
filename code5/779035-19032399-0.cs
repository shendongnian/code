    public virtual customer Load(customer paramEntity)
    {
        using (BillingDbContext bd = new BillingDbContext())
        {
            var dbEntity = (from s in bd.customer
                        select s).First();
            Mapper.Map(dbEntity, paramEntity);
        }
    
        return paramEntity;
    }
