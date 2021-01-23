    string URI = "http://url.php";
            string myParameters = "username=myUsername&password=myPassword";
            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] =
                "application/x-www-form-urlencoded";
                string HtmlResult = wc.UploadString(URI, myParameters);
                dynamic stuff1 = Newtonsoft.Json.JsonConvert.DeserializeObject(HtmlResult);
            }
