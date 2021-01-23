    static void Consume_GetZipCodePlaceNameWithEndPoint(Args _args)
    {
    	DynamicsAxServices.WebServices.ZipCode.USAZipCodeServiceRef.PostalCodeServiceClient postalServiceClient;
    	DynamicsAxServices.WebServices.ZipCode.USAZipCodeServiceRef.PostalCodepostalCode;
    	System.ServiceModel.Description.ServiceEndpoint endPoint;
    	System.ServiceModel.EndpointAddress endPointAddress;
    	System.Exception exception;
    	System.Type type;
    	;
    	
	try
	{
		// Get the .NET type of the client proxy
		type = CLRInterop::getType('DynamicsAxServices.WebServices.ZipCode.USAZipCodeServiceRef.PostalCodeServiceClient');
		
		// Let AifUtil create the proxy client because it uses the VSAssemblies path for the config file
		postalServiceClient = AifUtil::createServiceClient(type);
		
		// Create and endpoint address, This should be a parameter stored	in the system
		endPointAddress = new System.ServiceModel.EndpointAddress("http://www.restfulwebservices.net/wcf/USAZipCodeService.svc");
		
		// Get the WCF endpoint
		endPoint = postalServiceClient.get_Endpoint();
		
		// Set the endpoint address.
		endPoint.set_Address(endPointAddress);
		
		// Use the zipcode to find a place name
		postalCode = postalServiceClient.GetPostCodeDetailByPostCode("10001"); // 10001 is New York
		
		// Use the getAnyTypeForObject to marshal the System.String to an Ax anyType
		// so that it can be used with info()
		info(strFmt('%1', CLRInterop::getAnyTypeForObject(postalCode.get_PlaceName())));
	}
	catch(Exception::CLRError)
	{
		// Get the .NET Type Exception
		exception = CLRInterop::getLastException();
		
		// Go through the inner exceptions
		while(exception)
		{
			// Print the exception to the infolog
			info(CLRInterop::getAnyTypeForObject(exception.ToString()));
			
			// Get the inner exception for more details
			exception = exception.get_InnerException();
		}
	}
}
