    // BaseAddress
    Console.WriteLine(serviceHost.BaseAddress);
    // Endpoints (non-MEX)
    foreach (ServiceEndpoint ep in serviceHost.Description.Endpoints)
    {
      if (serviceHost.BaseAddress.Any(uri => uri.Equals(ep.ListenUri) &&
          ep.Contract.ContractType != typeof(IMetadataException))
      {
        Console.WriteLine("ListenURI: " + ep.ListenUri);
        Console.WriteLine("  Name   : " + ep.Name);
        Console.WriteLine("  Binding: " + ep.Binding.GetType().FullName);
      }
    }
    // List of MEX endpoints:
    foreach (ServiceEndpoint ep in serviceHost.Description.Endpoints)
    {
      if (ep.Contract.ContractType == typeof(IMetadataExchange))
      {
        Console.WriteLine(ep.ListenUri.ToString());
      }
    }
