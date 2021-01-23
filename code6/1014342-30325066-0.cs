    [System.Web.Services.WebMethod]
        public static object GetEmailInfo(string UserName)
        {
            var http = (HttpWebRequest)WebRequest.Create("https://api.mailgun.net/v2/address/validate?address=" + UserName);
            http.Credentials = new NetworkCredential("api","public key");
            http.Timeout = 5000;
            try
            {
                var response = http.GetResponse();
                var stream = response.GetResponseStream();
                var sr = new StreamReader(stream);
                var content = sr.ReadToEnd();
                JSON.JsonObject js = new JSON.JsonObject(content);
                return Convert.ToBoolean(js["is_valid"]);
            }
            catch (Exception ex)
            {
                
            }
        }
