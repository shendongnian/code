C#
    public sealed class Node
    {
        public string Name { get; }
        public Action Action { get; }
        public LinkedList<Node> Descendants { get; }
        public Node(string name, Action action)
        {
            Name = name;
            Action = action;
            Descendants = new LinkedList<Node>();
        }
        public void AddDescendant(Node node) => Descendants.AddLast(node);
    }
Once you have this, you can create a simple tree: 
C#
    public Node CreateTree()
    {
        Node root = new Node("root", () => Console.WriteLine("1"));
        
        Node gen1_1 = new Node("gen1_1", () => Console.WriteLine("2"));
        Node gen1_2 = new Node("gen1_2", () => Console.WriteLine("3"));
        
        Node gen2_1 = new Node("gen2_1", () => Console.WriteLine("4"));
        Node gen2_2 = new Node("gen2_2", () => Console.WriteLine("5"));
        Node gen2_3 = new Node("gen2_3", () => Console.WriteLine("6"));
        Node gen2_4 = new Node("gen2_4", () => Console.WriteLine("7"));
        root.AddDescendant(gen1_1);
        root.AddDescendant(gen1_2);
        gen1_1.AddDescendant(gen2_1);
        gen1_1.AddDescendant(gen2_2);
        gen1_2.AddDescendant(gen2_3);
        gen1_2.AddDescendant(gen2_4);
        return root;
    } 
Then the simplest function ever, to create tasks out of the actions and run them in an async way:
C#
    public async Task ExecuteAll(Node root)
    {
        await Task.Run(root.Action);
        await Task.WhenAll(root.Descendants.Select(ExecuteAll));
    }
And this is the test:
C# 
    [Test]
    public async Task Test()
    {
        var root = CreateTree();
        Console.WriteLine("start");
        await ExecuteAll(root);
        Console.WriteLine("finish");
    }
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/xtNW9.png
