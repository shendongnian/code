    string jsonData = Request.Form[0];
    Response.Write(jsonData);
    Response.Write("<br/>");
    PiwikDbData[] visitlist;
    
    //deserialize json array
    using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonData)))
    {
    	DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(PiwikDbData[]));
    	visitlist = (PiwikDbData[])serializer.ReadObject(stream);
    }
    
    Response.Write(visitlist.Length);
