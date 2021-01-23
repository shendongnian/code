    public class Node
    {
        public int Data { get; set; }
        public List<Node> Children { get; set; }
        public Node()
        {
            Children = new List<Node>();
        }
    }
    public class Graph
    {
        public List<Node> Nodes { get; set; }
        public Graph()
        {
            Nodes = new List<Node>();
        }
        public List<Node> TopologicSort()
        {
            var results = new List<Node>();
            var seen = new List<Node>();
            var pending = new List<Node>();
            Visit(Nodes, results, seen, pending);
            return results;
        }
        private void Visit(List<Node> graph, List<Node> results, List<Node> dead, List<Node> pending)
        {
            // Foreach node in the graph
            foreach (var n in graph)
            {
                // Skip if node has been visited
                if (!dead.Contains(n))
                {
                    if (!pending.Contains(n))
                    {
                        pending.Add(n);
                    }
                    else
                    {
                        Console.WriteLine(String.Format("Cycle detected (node Data={0})", n.Data));
                        return;
                    }
                    // recursively call this function for every child of the current node
                    Visit(n.Children, results, dead, pending);
                    
                    if (pending.Contains(n))
                    {
                        pending.Remove(n);
                    }
                    dead.Add(n);
                    // Made it past the recusion part, so there are no more dependents.
                    // Therefore, append node to the output list.
                    results.Add(n);
                }
            }
        }
    }
