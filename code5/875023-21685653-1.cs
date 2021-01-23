    class Example
    {
        public List<Node> InitGraph()
        {
            var nodes = new Dictionary<string, Node>();
            nodes.Add("Head", new Node("Head"));
            nodes.Add("T1", new Node("T1"));
            nodes.Add("T2", new Node("T2"));
            // While that works, a method is nicer:
            nodes.Add("C1");
            // These two lines should really be factored out to a single method call
            nodes["Head"].Successors.Add(nodes["T1"]);
            nodes["T1"].Predecessors.Add(nodes["Head"]);
            nodes["Head"].Successors.Add(nodes["T2"]);
            nodes["T2"].Predecessors.Add(nodes["Head"]);
            // Yes. Much nicer
            nodes.Connect("Head", "C1");
            nodes.Connect("T1", "C1");
            nodes.Connect("T2", "C1");
            var nodelist = new List<Node>(nodes.Values);
            return nodelist;
        }
    }
    public static class NodeHelper
    {        
        public static void Add(this Dictionary<string, Node> dict, string nodename)
        {
            dict.Add(nodename, new Node(nodename));
        }
        public static void Connect(this Dictionary<string, Node> dict, string from, string to)
        {
            dict["Head"].Successors.Add(dict["T2"]);
            dict["T2"].Predecessors.Add(dict["Head"]);
        }
    }
    public class Node
    {
        public string Name { get; set; }
        public int Coolness { get; set; }
        public List<Node> Predecessors { get; set; }
        public List<Node> Successors { get; set; }
        public Node()
        {
            Coolness = 1;
        }
        public Node(string name) : this()
        {
            this.Name = name;
        }
    }
