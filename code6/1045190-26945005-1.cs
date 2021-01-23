    public static void PrintParseTree(ParseTreeNode node, int level = 0)
    {
    	for (var levelIndex = 0; levelIndex < level; levelIndex++)
    	{
    		Console.Write("\t");
    	}
    
    	Console.WriteLine(node);
    
    	foreach (var child in node.ChildNodes)
    	{
    		PrintParseTree(child, level + 1);
    	}
    }
