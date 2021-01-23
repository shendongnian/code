    public ActionResult action(Object Message)
    {    
        // deserialise if Object Message is a string
        var serializer = new JavaScriptSerializer();
        var c = serializer.Deserialize<YourClass>(Message);
        // deserialise if Object Message is a JsonObject
        var serializer = new DataContractJsonSerializer(typeof(YourClass));
        var c = (YourClass)serializer.ReadObject(Message);
    
        return PartialView(Message);
    }
