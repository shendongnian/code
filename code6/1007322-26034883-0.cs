    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://api.issuu.com/query?action=issuu.documents.list" +
                    "&apiKey=Inser Your API Key" +
                    "&format=json" +
                    "&documentUsername=User of the account you want to make a request" +
                    "&pageSize=100&resultOrder=asc" +
                    "&responseParams=name,documentId,pageCount" +
                    "&username=Insert your ISSUU username" +
                    "&token=Insert Your Token here");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "application/json";
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    var responseValue = string.Empty;
                    // grab the response  
                    using (var responseStream = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(responseStream))
                        {
                            responseValue = reader.ReadToEnd();
                        }
                    }
                    if (responseValue != "")
                    {
                        List<string> lista_linkss = new List<string>();
                        JObject ApiRequest = JObject.Parse(responseValue);
                        //// get JSON result objects into a list
                        IList<JToken> results = ApiRequest["rsp"]["_content"]["result"]["_content"].Children()["document"].ToList();
                        for (int i = 0; i < results.Count(); i++)
                        {
                            Folheto folheto = new Folheto();
                            folheto.name = results[i]["name"].ToString();
                            folheto.documentId = results[i]["documentId"].ToString();
                            folheto.pageCount = Int32.Parse(results[i]["pageCount"].ToString());
                            string _date = Newtonsoft.Json.JsonConvert.SerializeObject(results[i]["uploadTimestamp"], Formatting.None, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd hh:mm:ss" }).Replace(@"""", string.Empty);
                            folheto.uploadTimestamp = Convert.ToDateTime(_date);
                            if (!lista_nomes_Sirena.Contains(folheto.name))
                            {
                                list.Add(folheto);
                            }
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
