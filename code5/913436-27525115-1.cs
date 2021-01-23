        static public HtmlElement GetLiveElement(HtmlNode node, HtmlDocument doc)
        {
            var pattern = @"/(.*?)\[(.*?)\]"; // like div[1]
            // Parse the XPath to extract the nodes on the path
            var matches = Regex.Matches(node.XPath, pattern); 
            List<DocNode> PathToNode = new List<DocNode>();
            foreach (Match m in matches) // Make a path of nodes
            {
                DocNode n = new DocNode();
                n.Name = n.Name = m.Groups[1].Value;
                n.Pos = Convert.ToInt32(m.Groups[2].Value)-1;
                PathToNode.Add(n); // add the node to path 
            }
            HtmlElement elem = null; //Traverse to the element using the path
            if (PathToNode.Count > 0)
            {
                elem = doc.Body; //begin from the body
                foreach (DocNode n in PathToNode)
                {
                    //Find the corresponding child by its name and position
                    elem = GetChild(elem, n);                    
                }
            }
            return elem;
        }
