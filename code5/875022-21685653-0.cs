	var nodes = new Dictionary<string, Node>();
	
	// Make a small helper method for this line
	// like AddNode(string name)
	nodes.Add("Head", new Node("Head"));
	nodes.Add("T1", new Node("T1"));
	nodes.Add("T2", new Node("T2"));
	// These two lines should really be factored out to a single method call
	// like MakeConnection(Node from, Node to)
	nodes["Head"].Successor.Add(nodes["T1"]);
	nodes["T1"].Predecessor.Add(nodes["Head"]);
	
	nodes["Head"].Successor.Add(nodes["T2"]);
	nodes["T2"].Predecessor.Add(nodes["Head"]);
	var list = new List<Node>(nodes.Values);
