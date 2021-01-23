    public static AuthTokenResponse GetUserToken(string username, string password)
            {
                string _jsonstringparams =
                    String.Format("{{ \"Password\": \"{0}\", \"UserId\": \"{1}\"}}", password, username);
                string _webservicesurl = ConfigurationManager.AppSettings["WebservicesUrl"];
                HttpWebRequest _requestclient = (HttpWebRequest)WebRequest.Create(String.Format("{0}?format=Json", _webservicesurl));
                _requestclient.ContentType = "application/json";
                _requestclient.Method = "POST";
                using (var streamWriter = new StreamWriter(_requestclient.GetRequestStream()))
                {
                    streamWriter.Write(_jsonstringparams);
                    streamWriter.Flush();
                    streamWriter.Close();
                    var httpResponse = (HttpWebResponse)_requestclient.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        _responsecontent = streamReader.ReadToEnd();
                    }
                    AuthTokenResponse _clienttoken = JsonConvert.DeserializeObject<AuthTokenResponse>(_responsecontent);
                    return _clienttoken;
                }
            }
