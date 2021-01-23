    public class Node
    {
       public object Data { get; set }
       public bool Active { get; set; }
       public List<Node> Nodes { get; set; }
       public IEnumerable<Node> ActiveNodes {
           get {
               foreach (var node in this.Nodes)
                   if (node.Active)
                       yield return node;
           }
       }
    }
