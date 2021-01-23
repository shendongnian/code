    using System;
    using System.Collections.Generic;
    static class Program
    {
        static void Main()
        {
            string input = "(SENT (VBP (HPP (HP Vem))(VB kan)(VBP (VB få)(PMP (PM ATP)))(MADP (MAD ?))))";
            Node root = new Node(), current = root;
            var ast = new Stack<Node>();
            foreach (var token in Tokenize(input))
            {
                switch(token)
                {
                    case "(":
                        // new sub-node
                        Node next = new Node();
                        current.Children.Add(next);
                        ast.Push(current);
                        current = next;                    
                        break;
                    case ")":
                        // go back a level
                        current = ast.Pop();
                        break;
                    case " ":
                        // nothing
                        break;
                    default:
                        if (current.Value == null)
                            current.Value = token;
                        else
                            current.Args.Add(token);
                        break;
    
                }
            }
            if (ast.Count != 0) throw new InvalidOperationException("unbalanced");
    
            Queue<Node> ancestors = new Queue<Node>();
            Write(ancestors, root);
        }
    
        private static void Write(Queue<Node> ancestors, Node node)
        {
            if(node.Children.Count == 0)
            {
                foreach(var parent in ancestors)
                {
                    if (!string.IsNullOrWhiteSpace(parent.Value))
                    {
                        Console.Write(parent.Value);
                        Console.Write(" -> ");
                    }
                }
                Console.WriteLine(node.Value);
            }
            else
            {
                ancestors.Enqueue(node);
                foreach (var child in node.Children)
                {
                    Write(ancestors, child);
                }
                ancestors.Dequeue();
            }
        }
        class Node
        {
            public string Value { get; set; }
            private readonly List<Node> children = new List<Node>();
            private readonly List<string> args = new List<string>();
            public List<Node> Children { get { return children; } }
            public List<string> Args { get { return args; } }
        }
        static IEnumerable<string> Tokenize(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) yield break;
    
            int last = -1, next;
            char[] splits = {'(', ')', ' '};
            while((next = value.IndexOfAny(splits, ++last)) >= 0)
            {
                if (last != next) yield return value.Substring(last, next - last);
                yield return value[next].ToString();
                last = next;
            }
        }
    }
