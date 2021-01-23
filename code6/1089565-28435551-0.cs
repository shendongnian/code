    public static string sourceCache (string URL)
        {
            string sourceURL = URL;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sourceURL);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;
                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }
                string data = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
                if (data.Contains("base href"))
                {
                    return data;
                }
                else
                {
                    //we need to insert the base href with the source url
                    data = basecache(data, URL);
                    return data;
                }                
            }
            return "couldn't retrieve cache";
        }
        public static string basecache (string htmlsource, string urlsource)
        {
            //make sure there is a head tag
            if (htmlsource.IndexOf("<head>") != -1)
            {
                int headtag = htmlsource.IndexOf("<head>");
                string newhtml = htmlsource.Insert(headtag + "<head>".Length, "<base href='" + urlsource + "'/>");
                return newhtml;
            }
            else if(htmlsource.IndexOf("&lt;head&gt;") != -1)
            {
                int headtag = htmlsource.IndexOf("&lt;head&gt;");
                string newhtml = htmlsource.Insert(headtag + "&lt;head&gt;".Length, "<base href='" + urlsource + "'/>");
                return newhtml;
            }
            else
            {
                return htmlsource;
            }
        }
