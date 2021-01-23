    public Task<tsResponse> GetViewString(HttpRequestMessage viewrequestMessage)
       {   	 
       	    tsResponse viewresultingMessage = null;
    		
            HttpResponseMessage viewrequestMessageresponse = await client.SendAsync(viewrequestMessage);
            if (viewrequestMessageresponse.IsSuccessStatusCode)
            {
                var viewresponsecontent = await viewrequestMessageresponse.Content.ReadAsStringAsync();
    
                XmlSerializer siteserializer = new XmlSerializer(typeof(tsResponse));
    
                using (TextReader reader = new StringReader(viewresponsecontent))
                {
                   viewresultingMessage = (tsResponse)siteserializer.Deserialize(reader);
                }
            }
    		
    		return viewresultingMessage;
       }
       
       public Task<tsResponse> GetViewImage(HttpRequestMessage viewImagerequestMessage)
       {   	 
       	    tsResponse viewImageresultingMessage = null;
            //Get View Data 
           
            HttpResponseMessage viewImagewrequestMessageresponse = await client.SendAsync(viewImagerequestMessage);
            if (viewImagewrequestMessageresponse.IsSuccessStatusCode)
            {
                var viewImageresponsecontent = await viewImagewrequestMessageresponse.Content.ReadAsByteArrayAsync();
    
                XmlSerializer siteserializer = new XmlSerializer(typeof(tsResponse));
    
                using (var ms = new MemoryStream(viewImageresponsecontent))
                {
                    return Image.FromStream(ms);                
                }
            }
       }
