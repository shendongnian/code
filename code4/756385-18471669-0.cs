    [Gtk.TreeNode]
    public class MyTreeNode : Gtk.TreeNode 
    {        
        public MyTreeNode(string text)
        {
            Text = text;
        }
        [Gtk.TreeNodeValue(Column=0)]
        public string Text;
    }
