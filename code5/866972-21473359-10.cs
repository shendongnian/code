    private void PrintTree(IEnumerable<Node> nodes, int indent = 0)
    {
    	foreach(var root in nodes)
    	{
    		Console.WriteLine(string.Format("{0}{1}", new String('-', indent), root.Id));
    		PrintTree(root.Children, indent + 1);
    	}
    }
