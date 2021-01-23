    var reReq = new RetrieveEntityRequest();
    reReq.EntityFilters = EntityFilters.All;
    reReq.RetrieveAsIfPublished = true;
    reReq.LogicalName = "opportunity";
    
    var reRes = (RetrieveEntityResponse)conn.Execute(reReq);
    
    foreach (var att in reRes.EntityMetadata.Attributes.OrderBy (a => a.LogicalName))
    {
    	Console.WriteLine("{0} IsLogical={1}",att.LogicalName, att.IsLogical.Value);
    }
