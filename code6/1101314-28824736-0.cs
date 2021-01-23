    // Set up request
    string postData = @"""Hello World!""";
    HttpWebRequest request = 
         (HttpWebRequest)WebRequest.Create("http://MyIP/Host/EchoWithPost");
    request.Method = "POST";
    request.ContentType = "text/json";
    byte[] dataBytes = new ASCIIEncoding().GetBytes(postData);
    request.ContentLength = dataBytes.Length;
    using (Stream requestStream = request.GetRequestStream())
    {
         requestStream.Write(dataBytes, 0, dataBytes.Length);
    }
    
    // Get and parse response
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    string responseString = string.Empty;
    using (var responseStream = new StreamReader(response.GetResponseStream()))
    {
         //responseData currently will be in XML format 
         //<string xmlns="http://schemas.microsoft.com/2003/10/Serialization/">Hello World!</string>
         var responseData = responseStream.ReadToEnd();
         responseString = System.Xml.Linq.XDocument.Parse(responseData).Root.Value;
    }
               
    // display response - Hello World!
    Console.WriteLine(responseString);
    Console.ReadKey(); 
