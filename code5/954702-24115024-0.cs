     HtmlWeb web = new HtmlWeb();
     HtmlDocument doc = web.Load(url);
     doc.DocumentNode.Descendants()
                                .Where(n => n.Name == "script" || n.Name == "style" || n.Name == "#comment")
                                .ToList()
                                .ForEach(n => n.Remove());
                string s = doc.DocumentNode.InnerText;
                TextArea1.Value = Regex.Replace(s, @"\t|\n|<.*?>","");
