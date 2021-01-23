    namespace ConsoleApplication3
    {
        using System.Collections.Generic;
    
        public class Tree
        {
            public int Value { get; set; }
    
            public List<Tree> TreeNode
            {
                get;
                set;
            }
            public Tree()
            {
                this.TreeNode = new List<Tree>();
            }
        }
    
        public class Program
        {
            public static void Main()
            {
                Program pro = new Program();
                Tree tree = new Tree();
                tree.TreeNode.Add(new Tree() { Value = 1 });
                tree.TreeNode.Add(new Tree() { Value = 2 });
                tree.TreeNode.Add(new Tree() { Value = 3 });
                tree.TreeNode.Add(new Tree() { Value = 4 });
                pro.DepthFirstSearch(2, tree);
            }
    
            private Tree DepthFirstSearch(int searchValue, Tree root)
            {
                if (searchValue == root.Value)
                {
                    return root;
                }
    
                Tree treeFound = null;
                foreach (var tree in root.TreeNode)
                {
                    treeFound = DepthFirstSearch(searchValue, tree);
                    if (treeFound != null)
                    {
                        break;
                    }
                }
    
                return treeFound;
    
            }
        }
    }
