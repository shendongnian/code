        static async Task<Stream> LoadStream()
        {
            var hc = new HttpClient();
            var stream = await hc.GetStreamAsync("http://www.rtp.pt/play/podcast/469");
            return stream;
        }
        static void Main(string[] args)
        {
            var xd2 = new XmlDocument();
            xd2.Load(LoadStream().Result);
            var node_titles2 = xd2.DocumentElement.SelectNodes("//item/title");
            Console.WriteLine(node_titles2.Count);
        }
