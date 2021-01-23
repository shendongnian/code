    // Identify the service binding and the user.
    ExchangeServiceBinding service = new ExchangeServiceBinding();
    service.RequestServerVersionValue = new RequestServerVersion();
    service.RequestServerVersionValue.Version = ExchangeVersionType.Exchange2010;
    service.Credentials = new NetworkCredential("<username>", "<password>", "<domain>");
    service.Url = @"https://<FQDN>/EWS/Exchange.asmx";
