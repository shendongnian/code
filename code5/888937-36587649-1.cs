    System.Net.ServicePoint servicePoint =
         System.Net.ServicePointManager.FindServicePoint(myWcfService.Endpoint.Address.Uri);
    if (servicePoint.Expect100Continue == true)
    { 
        //should happen only once for each URL
        servicePoint.Expect100Continue = false;
    }
    // now execute some service operation 
 
