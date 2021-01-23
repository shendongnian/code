        class RoomInfo
        {
            public String Name { get; set; }
            public Dictionary<String, Double> Prices { get; set; }
        }
        private static void HtmlFile()
        {
            List<RoomInfo> rooms = new List<RoomInfo>();
            HtmlDocument document = new HtmlDocument();
            document.Load("file.txt");
            
            var h2Nodes = document.DocumentNode.SelectNodes("//h2");
            foreach (var h2Node in h2Nodes)
            {
                RoomInfo roomInfo = new RoomInfo
                {
                    Name = h2Node.InnerText.Trim(),
                    Prices = new Dictionary<string, double>()
                };
                var labels = h2Node.NextSibling.NextSibling.SelectNodes(".//label");
                foreach (var label in labels)
                {
                    roomInfo.Prices.Add(label.InnerText.Trim(), Convert.ToDouble(label.Attributes["precio"].Value, CultureInfo.InvariantCulture));
                }
                rooms.Add(roomInfo);
            }
        }
