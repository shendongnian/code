    public class Node {
        public List<Node> Children {get;set;}
        public string Label {get;set;}
    }
    
    public static void Print(Node node, string result)
    {                        
        if (node.Children == null || node.Children.Count == 0)
        {
            Console.WriteLine(result);
            return;
        }
        foreach(var child in node.Children)
        {
            Print(child, result + child.Label);
        }
    }
