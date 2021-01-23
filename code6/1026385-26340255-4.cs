    class Program
    {
        static void Main()
        {
            var prog = new Program();
            prog.handleNode(new DecisionNode());
            prog.handleNode(new Node());
        }
        void handleNode(Node node)
        {
            var viewable = node as IViewable;
            System.Console.WriteLine("{0}: {1}",
                node.GetType().Name,
                viewable != null);
        }
    }
    interface IViewable { }
    class Node { }
    class DecisionNode : Node, IViewable { }
