    var contacts = new List<dynamic>();
    
    contacts.Add(new ExpandoObject());
    contacts[0].Name = "Patrick Hines";
    contacts[0].Phone = "206-555-0144";
    
    contacts.Add(new ExpandoObject());
    contacts[1].Name = "Ellen Adams";
    contacts[1].Phone = "206-555-0155";
    // DataTable Instance...
    DataTable table = new DataTable();
    
    //Get all properties of contract list items
    var properties = contacts.GetType().GetProperties();
    
    // Remove contract list property
    properties = properties.ToList().GetRange(0, properties.Count() - 1).ToArray();
    
    // Add column as named by property name
    properties.ToList().ForEach(p => table.Columns.Add(p.Name,typeof(string)));
    
    // Add rows from contracts list
    contacts.ForEach(x =>  table.Rows.Add(x.Name,x.Phone));
