     JavaScriptSerializer serializer = new JavaScriptSerializer();
     List<Returnable> deserialize = serializer.Deserialize<List<Returnable>>(order);
     foreach(Returnable returnable in deserialize)
     {
         // Iterate through all of your passed data.
     }
     List<SendInformation> responseObject = new List<SendInformation>();
     responseObject.Add(new SendInformation() { Total = "value", Tax = "value" });
     string response = serializer.Serialize(responseObject);
     Response.Write(response);
     Response.End();
