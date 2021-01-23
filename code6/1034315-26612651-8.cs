    void setCols()
    {
        List<SBBTreeNode<string>> FT = flatTree;
        int levelMax   = FT.Last().Row;
        int LMaxCount = FT.Count(n => n.Row == levelMax);
        int LMaxCount1 = FT.Count(n => n.Row == levelMax-1);
        if (LMaxCount1 > LMaxCount)
          { LMaxCount = LMaxCount1; levelMax = levelMax - 1; }
        int c = 1;
        foreach (SBBTreeNode<string> node in FT) if (node.Row == levelMax)
            {
                node.Col = c++;
                if (node.Left != null) node.Left.Col = c - 1;
                if (node.Right != null) node.Right.Col = c + 1;
            }
        List<SBBTreeNode<string>> Exceptions = new List<SBBTreeNode<string>>();
        for (int n = FT.Count- 1; n >= 0; n--)
        {
           SBBTreeNode<string> node = FT[n];
           if (node.Row < levelMax)
           {
              if (node.IsHorizontal) node.Col = node.Left.Col + 1;
              else if ((node.Left == null) | (node.Right == null)) {Exceptions.Add(node);}
              else node.Col = (node.Left.Col + node.Right.Col) / 2;
           }
        }
        // partially filled nodes will need extra attention
        foreach (SBBTreeNode<string> node in Exceptions) 
                                     textBox1.Text += "\r\n >>>" + node.Data;
        maxLevels = levelMax;
        maxItemsPerRow =  LMaxCount;
    }
