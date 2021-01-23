        public static void PostJsonDataToApi(string jsonData)
        {
           
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.somewhere.com/v2/cases");
            httpWebRequest.ReadWriteTimeout = 100000; //this can cause issues which is why we are manually setting this
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Accept = "*/*";
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers.Add("Authorization", "Basic ThisShouldbeBase64String"); // "Basic 4dfsdfsfs4sf5ssfsdfs=="
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
               // we want to remove new line characters otherwise it will return an error
                jsonData= thePostBody.Replace("\n", ""); 
                jsonData= thePostBody.Replace("\r", "");
                streamWriter.Write(jsonData);
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {
                HttpWebResponse resp = (HttpWebResponse)httpWebRequest.GetResponse();
                string respStr = new StreamReader(resp.GetResponseStream()).ReadToEnd();
                Console.WriteLine("Response : " + respStr); // if you want see the output
            }
            catch(Exception ex)
            {
             //process exception here   
            }
            
        }
