    class Node
    {
        public Node()
        {
            Children = new List<Node>();
        }
    
        public string Name { get; set; }
        public List<Node> Children { get; set; }
    }
    Dictionary<string, string> dict = new Dictionary<string, string>();
    dict.Add("Kitchen supplies", "Shopping / Housewares");
    dict.Add("Groceries", "Shopping / Housewares");
    dict.Add("Cleaning supplies", "Shopping / Housewares");
    dict.Add("Office supplies", "Shopping / Housewares");
    dict.Add("Retile kitchen", "Shopping / Remodeling");
    dict.Add("Ceiling", "Shopping / Remodeling / Paint bedroom");
    dict.Add("Walls", "Shopping / Remodeling / Paint bedroom");
    dict.Add("Misc", null);
    dict.Add("Other", "Shopping / Remodeling");
    
    Node root = new Node();
    foreach (KeyValuePair<string, string> kvp in dict)
    {
        Node parent = root;
        if (!string.IsNullOrEmpty(kvp.Value))
        {
            Node child = null;
            foreach (string part in kvp.Value.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries))
            {
                string name = part.Trim();
                child = parent.Children.Find(n => n.Name == name);
                if (child == null)
                {
                    child = new Node { Name = name };
                    parent.Children.Add(child);
                }
                parent = child;
            }
        }
        parent.Children.Add(new Node { Name = kvp.Key });
    }
    
    //Using JSON.NET
     string output = JsonConvert.SerializeObject(root);
