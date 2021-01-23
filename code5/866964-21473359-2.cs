     class Node
     {
    	public int Id { get; set; }
    	public int? ParentId { get; set; }
    	
    	public List<Node> Children { get; set; }
     }
