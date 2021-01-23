    [HttpPost]
    public IHttpActionResult HotelAvailRQ(HttpRequestMessage request)
    {
    	// Parse the SOAP request to get the data payload
    	var xmlPayload = MyHelper.GetSoapXmlBody(request);
    
    	// Deserialize the data payload
    	var serializer = new XmlSerializer(typeof(OpenTravel.Data.CustomAttributes.OTA_HotelAvailRQ));
    	var hotelAvailRQ = (OpenTravel.Data.CustomAttributes.OTA_HotelAvailRQ)serializer.Deserialize(new StringReader(xmlPayload));
    
    	return Ok();
    }
