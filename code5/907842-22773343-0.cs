    static void Main(string[] args)
    {
        // clear the flags on P so unclosed elements in P will be auto closed.
        HtmlNode.ElementsFlags.Remove("p");
    
        // load the document
        HtmlDocument doc = new HtmlDocument();
        doc.Load("yourTestFile.htm");
    
        // build a list of nodes ordered by stream position
        NodePositions pos = new NodePositions(doc);
    
        // browse all tags detected as not opened
        foreach (HtmlParseError error in doc.ParseErrors.Where(e => e.Code == HtmlParseErrorCode.TagNotOpened))
        {
            // find the text node just before this error
            HtmlTextNode last = pos.Nodes.OfType<HtmlTextNode>().LastOrDefault(n => n.StreamPosition < error.StreamPosition);
            if (last != null)
            {
                // fix the text; reintroduce the broken tag
                last.Text = error.SourceText.Replace("/", "") + last.Text + error.SourceText;
            }
        }
    
        doc.Save(Console.Out);
    }
    public class NodePositions
    {
        public NodePositions(HtmlDocument doc)
        {
            AddNode(doc.DocumentNode);
            Nodes.Sort(new NodePositionComparer());
        }
    
        private void AddNode(HtmlNode node)
        {
            Nodes.Add(node);
            foreach (HtmlNode child in node.ChildNodes)
            {
                AddNode(child);
            }
        }
    
        private class NodePositionComparer : IComparer<HtmlNode>
        {
            public int Compare(HtmlNode x, HtmlNode y)
            {
                return x.StreamPosition.CompareTo(y.StreamPosition);
            }
        }
    
        public List<HtmlNode> Nodes = new List<HtmlNode>();
    }
