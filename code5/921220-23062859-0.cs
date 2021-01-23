    class Node {
      public int Id { get; set; }
      public int? ParentId { get; set; }
      public string Operator { get; set; }
      public Node Parent { get; set; }
      public IList<Node> Children { get; set; }
      public Node() {
        Children = new List<Node>();
      }
    }
