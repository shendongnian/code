       string sValue ="{"UserLoginName": "steve","UserID":"-2147483637","IsDeleted":"false"}";
       HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:54002/api/user/AddUser HTTP/1.1");
       byte[] data = Encoding.UTF8.GetBytes(sValue); // Input Data
       request.Method = "POST";
       request.Accept = "application/json";
       request.ContentType = "application/json";
       Stream dataStream = request.GetRequestStream();
       dataStream.Write(data, 0, data.Length);
       dataStream.Close();
       HttpWebResponse resp = (HttpWebResponse)request.GetResponse();
       StreamReader result = new StreamReader(resp.GetResponseStream());
       if(result !=null)
       {      
       if(!string.IsnullorEmpty(result.ReadToEnd()))
       {
        String sResponseData = result.ReadToEnd(); 
       }
       }
  
