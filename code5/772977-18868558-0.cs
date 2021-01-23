    public class Node
    {
        public object Data {get;set;}
        public bool Active {get;set;}
        public List<Node> Nodes {get;set;}
        public IEnumerable<Node> ActiveNodes
        {
            get 
            {
                return Nodes.Where(n => n.Active);
            }
        }
    }
