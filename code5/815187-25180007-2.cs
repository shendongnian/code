    DBEntities entity = new DBEntities();
    List<Section> result = entity.Sections.ToList();
    
    StiReport report = new StiReport();
    report.RegBusinessObject("Section",result);
    
    int busobjLevel = 1;
    report.Dictionary.SynchronizeBusinessObjects(busobjLevel);
    
    //in web you should call design with parameter like this
    StiWebDesigner1.Design(report);
