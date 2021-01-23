            var doc = (from e in XDocument.Load("Test.xml").Root.Elements("Company")
                               select new Company
                                  {    
                                     name=(string)e.Element("name"),
                                     MaintenancePercentage=(double)e.Element("MaintenancePercentage"),
                                     Sales=(from sl in e.Elements("Sales").Elements("Sale")
                                         select new Sals
                                           {
                                              Code=(string)sl.Element("Code"),
                                              Title=(string)sl.Element("Title"),
                                              Datetime=(DateTime)sl.Elemnt("Date"),
                                              Category==(string)sl.Element("Category"),
                                              Amount=(double)sl.Element("Amount")
          
                                           }).ToArray()
                                  }).ToList();
    var company = new Company();
    foreach(var Comp in doc)
    {
        company.name=Comp.name;
        company.MaintenancePercentage=Comp.MaintenancePercentage;
        
    }
    var cSales=new Sales();
    foreach(var salas in doc.Sales)
    {
        
            cSales.Code=salas.Code;
            cSales.Title=salas.Title;
            pcSales.DateTime=salas.Datetime;
            cSales.Category=salas.Category;
           cSales.Amount=salas.Amount;
    }
