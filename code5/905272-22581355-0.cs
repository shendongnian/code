    var result = stations.AsEnumerable()
                 .Where(r => r.Field<double>("Distance") < SP_Radius);
    if(result.Any())
    { 
       var NStations = result.OrderBy(r => r.Field<double>("Distance"))
                             .CopyToDataTable();
    } 
