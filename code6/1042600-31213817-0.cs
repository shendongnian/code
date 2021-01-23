    private bool PushNotification(string pushMessage)
    {
          bool isPushMessageSend = false;
    
          string urlpath = "https://api.parse.com/1/push";
          var httpWebRequest = (HttpWebRequest)WebRequest.Create(urlpath);
    
          string postString = "{ \"where\": { \"installationId\": \"DEVICE-INSTALATION-ID\" }, \"data\": { \"alert\": \"Special delivery! Just for you!\" } }";
       
          httpWebRequest.ContentType = "application/json";
          httpWebRequest.ContentLength = postString.Length;
          httpWebRequest.Headers.Add("X-Parse-Application-Id", "YOUR APP KEY");
          httpWebRequest.Headers.Add("X-Parse-REST-API-KEY", "YOUR REST API KEY");
          httpWebRequest.Method = "POST";
          StreamWriter requestWriter = new StreamWriter(httpWebRequest.GetRequestStream());
          requestWriter.Write(postString);
          requestWriter.Close();
          var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
          using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
          {
               var responseText = streamReader.ReadToEnd();
               JObject jObjRes = JObject.Parse(responseText);
               if (Convert.ToString(jObjRes).IndexOf("true") != -1)
               {
                    isPushMessageSend = true;
               }
          }
    
          return isPushMessageSend;
     }
