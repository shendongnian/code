    private TreeListNode FindTreeNode(TreeListNode node, Enumerations.ItemType type,
                                      Nullable<long> id)
    {
        foreach (TreeListNode child in node.Nodes) {
            if ((Enumerations.ItemType)child[2] == type &&
                (id == null || (long)child[0] == id.Value)) {
                return child;
            }
            if (child.HasChildren) {
                TreeListNode found = FindTreeNode(child, type, id);
                if (found != null) {
                    return found;
                }
            }
        }
        return null;
    }
