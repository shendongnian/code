    public string GetResponseStream(string sURL)
        {
            string strWebPage = "";
            // create request
            System.Net.WebRequest objRequest = System.Net.HttpWebRequest.Create(sURL);
            // get response
            System.Net.HttpWebResponse objResponse;
            objResponse = (System.Net.HttpWebResponse)objRequest.GetResponse();
            // get correct charset and encoding from the server's header
            string Charset = objResponse.CharacterSet;
            Encoding encoding = Encoding.GetEncoding(Charset);
            // read response
            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream(), encoding))
            {
                strWebPage = sr.ReadToEnd();
                // Close and clean up the StreamReader
                sr.Close();
            }
            return strWebPage;
        }
