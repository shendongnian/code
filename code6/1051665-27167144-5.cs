    public IQueryable<Orders> GetOpenOrders(string _iduni)
    {
        var orders = this.ObjectContext.Orders.Include("UnitDetail");
        var estatus = this.ObjectContext.Estatus;
        var units = this.ObjectContext.DetailsUnit;
        var servicetype = this.ObjectContext.ServiceType;
    
        var query =
          (from o in orders
           join e in estatus on o.ID equals e.IDOrder
           join u in units on o.IDUni equals u.IDUni
           join t in servicetype on u.IDType equals t.IDType
           where o.IDUni.Equals(_iduni)
           && !estatus.Any(oe => (oe.Estatus == "CANCELADA" || oe.Estatus == "CERRADA") 
           && oe.IDOrder == o.ID)
           select o).Distinct();
    
           return query.AsQueryable();
    }
