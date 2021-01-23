    Parallel.ForEach(service.IRN, x => 
    {
        XmlDocument xRequest = BuildServiceRequest(
           new ServiceRequest 
            {
                AccountNumber = service.AccountNumber, 
                MemberId = service.MemberId, 
                IRN = new List<string> { x }
            });
        Debug.Print("Service Call " + DateTime.Now.ToString("hh.mm.ss.ffffff"));
        XmlDocument xResponse = WebRequest.Submit(xRequest); 
        XmlResponse.Add(xResponse);
    });
