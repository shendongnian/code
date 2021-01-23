            byte[] buffer = Encoding.ASCII.GetBytes("username=Username&password=Password");
            HttpWebRequest WebReq = (HttpWebRequest) WebRequest.Create("http://api40.maildirect.se/User/Authorize");
            WebReq.Method = "POST";
            WebReq.ContentType = "application/x-www-form-urlencoded";
            WebReq.ContentLength = buffer.Length;
            Stream PostData = WebReq.GetRequestStream();
            PostData.Write(buffer, 0, buffer.Length);
            PostData.Close();
            HttpWebResponse WebResp = (HttpWebResponse) WebReq.GetResponse();
            //This token variable was something I missed creating and it also had to get the " removed to work properly.
            var token = new StreamReader(WebResp.GetResponseStream()).ReadToEnd().Replace("\"", "");
           
            WebReq = (HttpWebRequest) WebRequest.Create("http://api40.maildirect.se/Contacts");
            WebReq.Method = "GET";
            WebReq.ContentType = "application/json; charset=utf-8";
            // This is where another part of the problem was, sent in the wrong type to the header, but when I replaced it with the token variable it worked like a charm :)
            //WebReq.Headers.Add("Authorization", WebResp.ToString());
            
            WebReq.Headers.Add("Authorization", token);
            HttpWebResponse WebResp2 = (HttpWebResponse) WebReq.GetResponse();
