    static void main()
    {
        var treevwaccess = new System.Windows.Forms.TreeView();
        CheckAll(treevwaccess.Nodes);
    }
    static void CheckAll(System.Windows.Forms.TreeNodeCollection nodes )
    {
        foreach (System.Windows.Forms.TreeNode node in nodes)
        {
            var formid = node.Name;
            var access = node.Checked;
            user.updateaccesslevel(lblId.Text, formid, access);
            CheckAll(node.Nodes);
        }
    }
