    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
           {
               if (response.StatusCode != HttpStatusCode.OK)
                   Console.Out.WriteLine("Error fetching data. Server returned status code: {0}", response.StatusCode);
               using (StreamReader reader = new StreamReader(response.GetResponseStream()))
               {
                   var content = reader.ReadToEnd();
                   var Results = JsonConvert.DeserializeObject<dynamic>(content);
                   if (string.IsNullOrWhiteSpace(content))
                   {
                       Console.Out.WriteLine("Response contained empty body...");
                   }
                   else
                   {
                       Console.Out.WriteLine("Response Body: \r\n {0}", content);
                   }
               }
           }
