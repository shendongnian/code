    public class Program
    {
        public class TreeNode<T>
        {
            public List<TreeNode<T>> children = new List<TreeNode<T>>();
            public T thisItem;
            public TreeNode<T> parent;
        }
        public static void Main(string[] args)
        {
            var dict = new Dictionary<string, List<string>>
            {
                {"BKK", new List<string>{"SIN", "DXB", "CDG", "SFO"}},
                {"CDG" , new List<string>{"LHR", "SIN"}},
                {"JFK" , new List<string>{"CDG", "DXB"}},
                {"JNB" , new List<string>{"SIN"}},
                {"SIN" , new List<string>{"SFO", "BKK"}},
                {"SFO" , new List<string>{"JFK", "BKK", "LHR"}},
                {"LHR" , new List<string>{"CDG", "JFK", "DXB"}},
                {"YYZ" , new List<string>{"SFO", "JFK"}},
                {"DXB", new List<string> {"JNB", "SIN", "BKK"}}
            };
            var tree = BuildTree(dict, "CDG");
        }
        public static TreeNode<T> BuildTree<T>(Dictionary<T, List<T>> dictionary, T root)
        {
            var newTree = new TreeNode<T>
            {
                thisItem = root,
            };
            newTree.children = GetChildNodes(dictionary, newTree);
            
            return newTree;
        }
        public static List<TreeNode<T>> GetChildNodes<T>(Dictionary<T, List<T>> dictionary, TreeNode<T> parent)
        {
            var nodeList = new List<TreeNode<T>>();
            if (dictionary.ContainsKey(parent.thisItem))
            {
                foreach (var item in dictionary[parent.thisItem])
                {
                    var nodeToAdd = new TreeNode<T>
                    {
                        thisItem = item,
                        parent = parent,
                    };
                    if (!ContainedInParent(parent, item))
                    {
                        nodeToAdd.children = GetChildNodes(dictionary, nodeToAdd);
                    }
                    // output leaf node for debugging!
                    if (nodeToAdd.children.Count == 0)
                    {
                        Console.WriteLine(NodeString(nodeToAdd));
                    }
                    nodeList.Add(nodeToAdd);
                }
            }
            
            return nodeList;
        }
        private static string NodeString<T>(TreeNode<T> node)
        {
            return (node.parent != null ? NodeString(node.parent) + "->" : string.Empty) + node.thisItem;
        }
        private static bool ContainedInParent<T>(TreeNode<T> parent, T item)
        {
            var found = false;
            if (parent != null)
            {
                if (parent.thisItem.Equals(item))
                {
                    found = true;
                }
                else
                {
                    found = ContainedInParent(parent.parent, item);
                }
            }
            return found;
        }
    }
