        static async Task<string> Load()
        {
            var hc = new HttpClient();
            string s = await hc.GetStringAsync("http://www.rtp.pt/play/podcast/469");
            return s;
        }
        static void Main(string[] args)
        {
            
            var xd = new XmlDocument();
            string res = Load().Result;
            xd.LoadXml(res);
            var node_titles = xd.DocumentElement.SelectNodes("//item/title");
           
            Console.WriteLine(node_titles.Count);
        }
