    public static TreeNode DeepClone<TreeNode>(TreeNode obj)
    {
        TreeNode oldParent = obj.mParent;
        obj.mParent = null;
        using (var ms = new MemoryStream())
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(ms, obj);
            obj.mParent = oldParent;
    
            ms.Position = 0;
    
            TreeNode result = (TreeNode) formatter.Deserialize(ms);
            result.mParent = oldParent;
            return result;
        }
    }
