    class Program
    {
        public class Node
        {
            public Node()
            {
                Children = new List<Node>();
            }
            public int ID { get; set; }
            public List<Node> Children { get; set; }
        }
        public class NhNode
        {
            public int ID { get; set; }
            public int SponsorId { get; set; }
        }
        static Node ConvertToHierarchy(NhNode nhnode, IEnumerable<NhNode> nodes)
        {
            var node = new Node()
            {
                ID = nhnode.ID
            };
            foreach (var item in nodes.Where(p => p.SponsorId == nhnode.ID))
            {
                node.Children.Add(ConvertToHierarchy(item, nodes));
            }
            return node;
        }
        static void Main(string[] args)
        {
            List<NhNode> nhnodes = new List<NhNode>() {
                new NhNode() { ID = 10013, SponsorId = 10000 },
                new NhNode() { ID = 10624, SponsorId = 10013 },
                new NhNode() { ID = 10975, SponsorId = 10624 }
            };
            var node = ConvertToHierarchy(nhnodes.First(p => p.SponsorId == 10000), nhnodes);
        }
    }
