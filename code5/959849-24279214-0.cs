    public class MyTreeView : TreeView 
    {
        public int this[string nodeName] {
            var found = this.Nodes.FirstOrDefault(n=>n.Text == nodeName);
            return (found == null)?-1:found.Index;
        }
    }
