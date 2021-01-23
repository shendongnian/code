    public static void test(object[] objInput)
        {            
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("firstName", "test");
            data.Add("lastName", "test");
            String post_string = "";
            foreach (KeyValuePair<string, string> post_value in data)
            {
                post_string += post_value.Key + "=" + HttpUtility.UrlEncode(post_value.Value) + "&";
            }
            post_string = post_string.TrimEnd('&');
            string VOID_URL = "http://your uri///";
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(VOID_URL);           
            objRequest.Method = "POST";
            objRequest.Accept = "application/json";
            objRequest.ContentLength = post_string.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded; charset=utf-8";
            // post data is sent as a stream
            StreamWriter myWriter = null;
            myWriter = new StreamWriter(objRequest.GetRequestStream());
            myWriter.Write(post_string);
            myWriter.Close();
            // returned values are returned as a stream, then read into a string
            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader responseStream = new StreamReader(objResponse.GetResponseStream()))
            {
                post_string = responseStream.ReadToEnd();
                responseStream.Close();
            }
            System.Windows.Forms.MessageBox.Show("Response" + post_string);
        }
