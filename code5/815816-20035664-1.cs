        private static void SplitDocument()
        {
            var doc = new HtmlDocument();
            doc.Load("HtmlDoc.html");
            var links = doc.DocumentNode.SelectNodes("//a[@href]");
            var firstPart = GetFirstPart(doc.DocumentNode, links[0]).DocumentNode.InnerHtml;
            var secondPart = GetSecondPart(links[0]).DocumentNode.InnerHtml;
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
                var copyNode = curr.Item1.CloneNode(false);
                curr.Item2.AppendChild(copyNode);
                if (curr.Item1 == link)
                {
                    var nodeToRemove = NodeAndEmptyAncestors(copyNode);
                    nodeToRemove.ParentNode.RemoveChild(nodeToRemove);
                    break;
                }
                for (var i = curr.Item1.ChildNodes.Count - 1; i >= 0; i--)
                {
                    nodeStack.Push(new Tuple<HtmlNode, HtmlNode>(curr.Item1.ChildNodes[i], copyNode));
                }
            }
            return newDoc;
        }
        private static HtmlDocument GetSecondPart(HtmlNode link)
        {
            var nodeStack = new Stack<HtmlNode>();
            var newDoc = new HtmlDocument();
            var currNode = link;
            while (currNode.ParentNode != null)
            {
                currNode = currNode.ParentNode;
                nodeStack.Push(currNode.CloneNode(false));
            }
            var parent = newDoc.DocumentNode;
            while (nodeStack.Count > 0)
            {
                var node = nodeStack.Pop();
                parent.AppendChild(node);
                parent = node;
            }
            var newLink = link.CloneNode(false);
            parent.AppendChild(newLink);
            currNode = link;
            var newParent = newLink.ParentNode;
            while (currNode.ParentNode != null)
            {
                var foundNode = false;
                foreach (var child in currNode.ParentNode.ChildNodes)
                {
                    if (foundNode) newParent.AppendChild(child.Clone());
                    if (child == currNode) foundNode = true;
                }
                currNode = currNode.ParentNode;
                newParent = newParent.ParentNode;
            }
            var nodeToRemove = NodeAndEmptyAncestors(newLink);
            nodeToRemove.ParentNode.RemoveChild(nodeToRemove);
            return newDoc;
        }
        private static HtmlNode NodeAndEmptyAncestors(HtmlNode node)
        {
            var currNode = node;
            while (currNode.ParentNode != null && currNode.ParentNode.ChildNodes.Count == 1)
            {
                currNode = currNode.ParentNode;
            }
            return currNode;
        }
