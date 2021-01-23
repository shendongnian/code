        static void Main(string[] args)
        {
            string html = WebUtility.HtmlDecode("&lt;p&gt;LARGE&lt;/p&gt;&lt;p&gt;Lamb&lt;/p&gt;");
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            List<HtmlNode> spanNodes = doc.DocumentNode.Descendants().Where(x => x.Name == "p").ToList();
            foreach (HtmlNode node in spanNodes)
            {
                Console.WriteLine(node.InnerHtml);
            }
        }
