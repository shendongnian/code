    public class Round 
    {
       public Round Parent { get; set; }
       public int Depth { get; set; }
       public string Value { get; set; }
       private List<Round> _nodes;
       
       public ICollection<Round> Nodes { get { return _nodes; } }
       public void AddNode(Round node) {
          _nodes.Add(node);
       }
       public void RemoveNode(Round node) {
          _nodes.Remove(node);
       }
    }
