    public IQueryable<Orders> GetOpenOrders(string _iduni)
    {
        var query =
          (from o in this.ObjectContext.Orders.Include("UnitDetail")
           where o.IDUni.Equals(_iduni) 
               && !this.ObjectContext.Estatus.Any(oe => (oe.Estatus == "CANCELADA" || oe.Estatus == "CERRADA") 
           && oe.IDOrder == o.ID)
           select o).Distinct();
    
           return query.AsQueryable();
    }
