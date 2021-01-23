    //Create new instance of JsonObject
    MySerializeObject obj = new MySerializeObject();
    
    //Get the byte
    byte[] byteArray = Encoding.UTF8.GetBytes(resultJson);
    
    //Create Memorystream from the byteArray
    MemoryStream myMemoryStream = new MemoryStream(byteArray);
    
    //Create Json DataContract from serialize object
     DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(MySerializeObject));
    
    //Read Stream in object
     myMemoryStream.Position = 0;
    obj = (MySerializeObject)ser.ReadObject(myMemoryStream);
    
    //Close the stream
    myMemoryStream.Close();
