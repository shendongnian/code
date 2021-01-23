     System.IO.MemoryStream stream = new System.IO.MemoryStream();  
     StreamWriter writer = new StreamWriter(stream);
     writer.Write(myObject.One);  // here's where we actually write the data to the stream
     writer.Write(myObject.Two);
     writer.Write(myObject.Three);
     writer.Write(myObject.Four);    
     writer.Flush();   // make sure all the data in the stream writer ends up in the 
                       // underlying stream
     byte[] result = stream.ToArray();  // here's your resulting byte array
     stream.Dispose();   // don't forget to dispose of the stream!        
