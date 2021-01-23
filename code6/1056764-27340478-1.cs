        private readonly List<State> _allStates = new List<State>();
        private void button1_Click(object sender, EventArgs e)
        {
            GetStates();
            _allStates.ForEach(i => comboBox1.Items.Add(i.ToString()));
        }
        public void GetStates()
        {
            var wc = new WebClient {Proxy = null};
            var webDoc = new HtmlAgilityPack.HtmlDocument();
            var html = wc.DownloadString("http://goo.gl/8Mw3ud");
            webDoc.LoadHtml(html);
            foreach (var i in webDoc.DocumentNode.SelectNodes("//tr").Skip(1).Take(50))
            {
                _allStates.Add(
                    new State(i.Descendants("th").ToList()[0].Descendants("a").ToList()[0].InnerText,
                        i.Descendants("td").ToList()[0].InnerText));
            }
        }
        public class State
        {
            public State(string ab, string name)
            {
                Name = name;
                Abbreviation = ab;
            }
            public string Abbreviation { get; set; }
            public string Name { get; set; }
            public override string ToString()
            {
                return string.Format("{0} - {1}", Name, Abbreviation);
            }
        }
