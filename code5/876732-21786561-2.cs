    protected async static Task<string> PostToDBMultiPart(String APIcall, String parameters, byte[] File, string fileType)
        {
            String apiResponse;
            string responseBodyAsText;
            try
            {
                // Create a request using a URL that can receive a post. 
                string boundary = "----Locqus" + DateTime.Now.Ticks.ToString("x");
               // request.Method = "POST";
                var data = new Dictionary<string, string>();
                //parse parameters to name collection
                var preData = HttpUtility.ParseQueryString(parameters);
                //add data to dictionary
                foreach (string key in preData.AllKeys)
                {
                    data.Add(key, preData[key]);
                }
                
               var client = new HttpClient();
               var content = new MultipartFormDataContent(boundary);     
               //add parameters
               foreach (var item in data)
               {
                   content.Add(new StringContent(item.Value), item.Key);
               }
               //add file
                content.Add(new StreamContent(new MemoryStream(File)), "file", data["note"]);
                HttpResponseMessage response = client.PostAsync("https://api.url.com/api"+APIcall, content).Result;
                response.EnsureSuccessStatusCode();
                responseBodyAsText = response.Content.ReadAsStringAsync().Result;
                timer.Stop();
                TimeSpan timeTaken = timer.Elapsed;
                return responseBodyAsText;
                                     
            }
            catch (WebException e)
            {
                string responseFromServer = "";
                apiResponse = "error:" + Environment.NewLine + e.Message;
                if (e.Response != null)
                {
                    var reader = new StreamReader(e.Response.GetResponseStream());
                    responseFromServer = reader.ReadToEnd();
                }
                return apiResponse;
            }
        }
