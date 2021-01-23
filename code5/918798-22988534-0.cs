    class MyXml
    {
        public List<Node> AllNodes()
        {
            List<Node> allNodes = new List<Node>();
            foreach (var node in Content)
                AddNode(node, nodes);
        }
        public void AddNode(Node node, List<Node> nodes)
        {
            nodes.Add(node);
            foreach (var childNode in node.Nodes)
                AddNode(childNode, nodes);
        }
        public List<Node> AllNodesOfType(NodeType nodeType)
        {
           return AllNodes().Where(n => n.NodeType == nodeType);
        }
    }
