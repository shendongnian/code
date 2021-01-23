    public interface IMyNode
    {
        void Print();
    }
    public class A : IMyNode
    {
        public void Print()
        {
            Console.WriteLine("I am a child of T. A or B");
        }
    }
    public class C : IMyNode
    {
        public void Print()
        {
            Console.WriteLine("I am a child of A or B, I am C.");
        }
    }
    public class D : IMyNode
    {
        public void Print()
        {
            Console.WriteLine("I am a child of C. I am D.");
        }
    }
    public class CompositeMyNode : IMyNode
    {
        private readonly List<IMyNode> nodes;
 
        public CompositeMyNode()
        {
            nodes= new List<IMyNode>();
        }
        public void Add(IMyNode node)
        {
            nodes.Add(node);
        }
        public void AddRange(params IMyNode[] node)
        {
            nodes.AddRange(node);
        }
        public void Delete(IMyNode node)
        {
            nodes.Remove(node);
        }
        public void Print()
        {
            foreach (IMyNode childMyNode in nodes)
            {
                childMyNode.Print();
            }
        }
    }
