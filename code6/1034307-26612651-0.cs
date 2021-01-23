    void drawTree(Graphics G)
    {
        if (tree.Count <= 0) return;
        if (maxItemsPerRow <= 0) return;
        if (maxLevels <= 0) return;
        int width = (int)G.VisibleClipBounds.Width / (maxItemsPerRow + 2);
        int height = (int)G.VisibleClipBounds.Height / (maxLevels + 2);
        int side = width / 4;
        int textOffsetX = 3;
        int textOffsetY = 5;
        int graphOffsetY = 50;
        Size squaresize = new Size(side * 2, side * 2);
        foreach (SBBTreeNode<string> node in flatTree)
        {
            Point P0 = new Point(node.Col * width, node.Row * height + graphOffsetY);
            Point textPt = new Point(node.Col * width  + textOffsetX, 
                                        node.Row * height + textOffsetY + graphOffsetY);
            Point midPt = new Point(node.Col * width + side, 
                                    node.Row * height + side + graphOffsetY);
            if (node.Left != null)
                G.DrawLine(Pens.Black, midPt, 
                    new Point(node.Left.Col * width + side, 
                              node.Left.Row * height + side + graphOffsetY));
            if (node.Right != null)
                G.DrawLine(Pens.Black, midPt, 
                    new Point(node.Right.Col * width + side, 
                              node.Right.Row * height + side + graphOffsetY));
            G.FillEllipse(Brushes.Beige, new Rectangle(P0, squaresize));
            G.DrawString(node.Data, Font, Brushes.Black, textPt);
            G.DrawEllipse(Pens.Black, new Rectangle(P0, squaresize));
        }
    }
