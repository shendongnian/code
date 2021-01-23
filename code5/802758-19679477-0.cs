    using (var twitpicResponse = (HttpWebResponse)request.GetResponse())
    {
       using (var reader = new StreamReader(twitpicResponse.GetResponseStream()))
       {
         JavaScriptSerializer js = new JavaScriptSerializer();
         var objText = reader.ReadToEnd();  
         MyObject myobj= (MyObject)js.Deserialize<MyObject>(objText);
       }
     }
