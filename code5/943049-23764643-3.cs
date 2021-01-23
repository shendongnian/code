    public void InsertNodeToTreeLDR(TreeNode newNode)
    {
        if( Root == null )
        {
            Root = newNode;
            return;
        }
        InsertNodeToTreeHelper( Root, newNode );           
    }
    private void InsertNodeToTreeHelper(TreeNode root, TreeNode newNode)
    {
        if (newNode.Data.CompareTo(root.Data) >= 0)
        {
            if( root.LeftChild == null )
            {
                root.LeftChild = newNode;
            }
            else
            {
                InsertNodeToTreeHelper( root.LeftChild, newNode);
            }
        }
        else
        {
            if( root.RightChild == null )
            {
                root.RightChild = newNode;
            }
            else
            {
                InsertNodeToTreeHelper( root.RightChild, newNode);
            }
        }
    }
