    string xml="<Employees><Employee><ID>1</ID><Address><City>Bangalore</City><CreatedOn>1-1-2012</CreatedOn></Address><Address><City>Pune</City><CreatedOn>1-10-2012</CreatedOn></Address></Employee><Employee><ID>2</ID><Address><City>Hyd</City><CreatedOn>1-1-2009</CreatedOn></Address><Address><City>Bombay</City><CreatedOn>1-1-2010</CreatedOn></Address></Employee></Employees>";
    
    XElement xe = XElement.Parse(xml);
    
    var query = xe
    .Elements("Employee")
    .Select
    (
    	x=>	new 
    	{
    		Addresses = x.Elements("Address")
    		.Select
    		(
    			z=>new 
    			{
    				ID = x.Element("ID").Value,
    				City = z.Element("City").Value,
    				CreatedOn = z.Element("CreatedOn").Value
    			}
    		).ToList()
    	}
    )
    .SelectMany (X=>X.Addresses);
    
    var record = query.Where (q => DateTime.Parse(q.CreatedOn)==query.Max (x => DateTime.Parse(x.CreatedOn))).SingleOrDefault ();
    
    Console.WriteLine("{0},{1},{2}",record.ID,record.City,record.CreatedOn);
