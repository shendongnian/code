    static void Main(string[] args)
            {
                const string API_KEY = "XXXXXXXXXXXXXXXXXXXXXXX";
    
    
                XmlDocument xdoc = MakeRequest("http://www.xmlsoccer.com/FootballDataDemo.asmx/GetAllLeagues", API_KEY);
    
                StringBuilder output = new StringBuilder();
    
    
                // Create an XmlReader
                using (XmlReader reader = new XmlNodeReader(xdoc))
                {
                    reader.ReadToFollowing("Id");
                    Console.WriteLine(reader.Name +" " + reader.ReadElementContentAsString());
                }
                Console.ReadKey();
                   
            }
    
            public static XmlDocument MakeRequest(string requestUrl, string API_KEY)
            {
                try
                {
    
                    requestUrl = requestUrl + "?ApiKey=" + API_KEY;
    
                    HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
    
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(response.GetResponseStream());
                    return (xmlDoc);
    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
    
                    Console.Read();
                    return null;
                }
            }
