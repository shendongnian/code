        public static string FlattenCssIntoHtml(string html)
        {
            Regex styleReg = new Regex(@"(.*?)\{(.*?)\}$", RegexOptions.Singleline | RegexOptions.Multiline | RegexOptions.CultureInvariant);
            Regex cssReg = new Regex(@"(.*?):(.*?)$", RegexOptions.Singleline | RegexOptions.Multiline | RegexOptions.CultureInvariant);
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            IEnumerable<HtmlNode> styleNode = doc.DocumentNode.SelectNodes("html[1]/head[1]/style[1]");
            // replace \r's as RegEx only matches \n to newline.
            foreach (Match match in styleReg.Matches(styleNode.First().InnerText.Replace("\r", "")))
            {
                if (match.Groups.Count == 3)
                {
                    List<HtmlNode> toSet = FindNodes(doc.DocumentNode.SelectSingleNode("html[1]/body[1]"), match.Groups[1].Value.Trim().Split(' '), 0);
                    foreach (Match cssMatch in cssReg.Matches(match.Groups[2].Value))
                    {
                        foreach (HtmlNode thisNode in toSet)
                        {
                            AddStyle(thisNode, cssMatch.Groups[1].Value.Trim(), cssMatch.Groups[2].Value.Trim());
                        }
                    }
                }
            }
            return doc.DocumentNode.OuterHtml;
        }
        private static List<HtmlNode> FindNodes(HtmlNode topNode, string[] toParse, int index)
        {
            IEnumerable<HtmlNode> myList;
            string selector = toParse[index];
            string elementName = "";
            string valueName = "";
            int valueType = 0;
            int idx = selector.IndexOfAny(new[] { '.', '#' });
            if (idx > -1)
            {
                elementName = selector.Substring(0, idx);
                valueName = selector.Substring(idx + 1);
                valueType = selector.Substring(idx, 1) == "." ? 1 : 2;
            }
            else
            {
                elementName = selector;
            }
            switch (valueType)
            {
                case 0:
                    myList = topNode.Descendants().Where(x => x.Name == elementName);
                    break;
                case 1:
                    myList = topNode.Descendants().Where(x => (elementName == "" || x.Name == elementName) && x.Attributes.Contains("class") && x.Attributes["class"].Value.Split().Contains(valueName));
                    break;
                case 2:
                    myList = topNode.Descendants().Where(x => (elementName == "" || x.Name == elementName) && x.Id == valueName);
                    break;
                default:
                    throw new NotImplementedException();
            }
            if (index == toParse.Length - 1)
            {
                return new List<HtmlNode>(myList);
            }
            List<HtmlNode> toReturn = new List<HtmlNode>();
            foreach (HtmlNode aNode in myList)
            {
                toReturn.AddRange(FindNodes(aNode, toParse, index + 1));
            }
            return toReturn;
        }
        private static void AddStyle(HtmlNode dest, string styleName, string styleValue)
        {
            if (!dest.Attributes.Contains("style"))
            {
                dest.Attributes.Add("style", styleName + ":" + styleValue);
            }
            else
            {
                HtmlAttribute attr = dest.Attributes["style"];
                if (!attr.Value.Split().Contains(styleName))
                {
                    attr.Value = attr.Value + " " +  styleName + ":" + styleValue;
                }
            }
        }
