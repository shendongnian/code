    public IQueryable<Orders> GetOpenOrders(string _iduni)
        {
            ObjectSet<Estatus> estatus = this.ObjectContext.Estatus;
            ObjectSet<DetailUnit> units = this.ObjectContext.DetailsUnit;
            ObjectSet<ServiceType> servicetype = this.ObjectContext.ServiceType;
        
            var query =
              (from o in this.ObjectContext.Orders
               join e in estatus on o.ID equals e.IDOrder
               join u in units on o.IDUni equals u.IDUni
               join t in servicetype on u.IDType equals t.IDType
               where o.IDUni.Equals(_iduni)
               && !estatus.Any(oe => (oe.Estatus == "CANCELADA" || oe.Estatus == "CERRADA") 
               && oe.IDOrder == o.ID)
               select o.Include("UnitDetail")).Distinct();
        
               return query.AsQueryable();
        }
