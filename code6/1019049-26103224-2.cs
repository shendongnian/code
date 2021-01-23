    //I only use this bc I don't know the full schema.
    class DTOCompany {
      public int ID {get;set;}
      public List<Orders> Orders {get;set;}
    }
    public List<Companies> GetCompaniesOrders() {
    
      using (var db = new Entities()) {
        return db.Companies
          .AsEnumerable() //may not be needed.
          .Join(db.Orders,
            c => CompanyId,
            o => o.CompanyId,
            (c,o) => new { Company = c, Orders = o})
          )
          .Select(co => new DTOCompany() {
            ID = co.Companies.CompanyId,
            Orders = co.Orders.ToList()
          })
          .ToList();
      }
    }
