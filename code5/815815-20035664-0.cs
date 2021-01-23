        private static void SplitDocument()
        {
            var doc = new HtmlDocument();
            doc.Load("HtmlDoc.txt");
            var links = doc.DocumentNode.SelectNodes("//a[@href]");
            var firstPart = GetFirstPart(doc.DocumentNode, links[0]).DocumentNode.InnerHtml;
        }
        private static HtmlDocument GetFirstPart(HtmlNode currNode, HtmlNode link)
        {
            var nodeStack = new Stack<Tuple<HtmlNode, HtmlNode>>();        
            var newDoc = new HtmlDocument();
            var parent = newDoc.DocumentNode;
            nodeStack.Push(new Tuple<HtmlNode, HtmlNode>(currNode, parent));
            while (nodeStack.Count > 0)
            {
                var curr = nodeStack.Pop();
                if (curr.Item1 == link) break;
                var copyNode = curr.Item1.CloneNode(false);
                curr.Item2.AppendChild(copyNode);
                for (var i = curr.Item1.ChildNodes.Count - 1; i >= 0; i--)
                {
                    nodeStack.Push(new Tuple<HtmlNode, HtmlNode>(curr.Item1.ChildNodes[i], copyNode));
                }
            }
            return newDoc;
        }
