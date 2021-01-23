    public class PathsResult<TNode> 
    {
        public IEnumerable<Node<TNode>> Nodes { get; set; }
        public IEnumerable<RelationshipInstance<object>> Relationships { get; set; }
    }
