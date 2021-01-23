    public void PrintTree(ParseTreeNode node, int level)
    {
        for(int i = 0; i < level; i++)
            Console.Write("  ");
        Console.WriteLine(node);
         
        foreach (ParseTreeNode child in node.ChildNodes)
          PrintTree(child, level + 1);
    }
