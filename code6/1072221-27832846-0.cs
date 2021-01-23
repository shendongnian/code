    public JsonResult GetCoursesCount()
            {
                const string apiKey = "[API KEY FROM MY DOCEBO PORTAL]";
                const string apiSecret = "[API SECRET FROM MY DOCEBO PORTAL]";
                const string doceboUrl = "[URL OF MY DOCEBO PORTAL]";
    
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
                    var listKeyValuePair = new List<KeyValuePair<string,string>>
                    {
                        new KeyValuePair<string, string>("from", "0"), 
                        new KeyValuePair<string, string>("count", "10")
                    };
    
                    var toEncodeWithSha1 = String.Format("{0},{1}", String.Join(",", listKeyValuePair.Select(n => n.Value)), apiSecret); // should the values be values or parameters??
    
                    var code = Sha1Hash(toEncodeWithSha1);
    
                    var toEncodeWithBase64 = String.Format("{0}:{1}", apiKey, code);
    
                    code = Base64Encode(toEncodeWithBase64);
    
                    var xAuthorisation = String.Format("Docebo {0}", code);
    
                    httpClient.DefaultRequestHeaders.Add("X-Authorization", xAuthorisation);
    
                    var content = new FormUrlEncodedContent(listKeyValuePair);
    
                    var userResult = httpClient.PostAsync(String.Format("{0}/api/user/listUsers", doceboUrl),
                        content).Result;
    
                    var responseByteArray = userResult.Content.ReadAsByteArrayAsync().Result;
    
                    var convertedResult = Encoding.UTF8.GetString(responseByteArray, 0, responseByteArray.Length);
    
                    var userData = JsonConvert.DeserializeObject<UserListResult>(convertedResult);
    
                    return new JsonResult { Data = userData, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }
    
            public class UserListResult
            {
                public List<dynamic> Users { get; set; }
                public bool Success { get; set; }
            }
    
            private string Sha1Hash(string input)
            {
                return string.Join(string.Empty, SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(input)).Select(x => x.ToString("x2")));
            }
    
            private string Base64Encode(string plainText)
            {
                var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                return Convert.ToBase64String(plainTextBytes);
            }
