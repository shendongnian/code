    using (var client = new WebClient()) //WebClient  
    {
       string mystring = "";               
      client.Headers.Add("Content-Type:application/json"); //Content-Type  
      client.Headers.Add("Accept:application/json");                      
      var dataa = Encoding.UTF8.GetBytes("{\"Username\":\"sdfsd\"}");                      
      byte[] a = client.UploadData("your API url", "POST",dataa);                        
      myString = Encoding.UTF8.GetString(a);
      
      }
