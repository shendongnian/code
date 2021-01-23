    //...
    using (Stream responseStream = response.GetResponseStream())
    {
        Response.BufferOutput= false;   // to prevent buffering 
        byte[] buffer = new byte[1024]; 
        int bytesRead = 0; 
        while ((bytesRead = responseStream.Read(buffer, 0, buffer.Length)) > 0)  
        { 
             Response.OutputStream.Write(buffer, 0, bytesRead); 
        }
    }
    //...
