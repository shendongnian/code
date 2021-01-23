    public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
     {
 
           //here you can  create a buffered message as the original message can accessed only once 
               //MemoryStream stream = new MemoryStream();
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Encoding = System.Text.Encoding.UTF8;
                StringWriter sw = new StringWriter();
                XmlWriter writer = XmlWriter.Create(sw, settings);
                
                MessageBuffer buffer = request.CreateBufferedCopy(int.MaxValue);
                //Create a copy of the message in order to continue the handling of te SOAP                 
                request = buffer.CreateMessage();
               request.WriteMessage(writer);
              //Recreate the message 
                 writer.Flush();
                //Flush the contents of the writer so that the stream gets updated
                 //you can log the str to the database 
                var str =  sw.ToString();
                request = buffer.CreateMessage();
    
      }
  
