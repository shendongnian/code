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
            webDoc.LoadHtml(wc.DownloadString("http://goo.gl/2R4ne1"));
            foreach (var descendents in webDoc.DocumentNode.SelectNodes("//tr").Skip(1).Take(50)
                .Select(i => i.Descendants("td").ToList()))
                _allStates.Add(new State(descendents[0].InnerText, descendents[1].InnerText));
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
