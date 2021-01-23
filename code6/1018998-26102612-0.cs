    internal sealed class Node
    {
        private readonly object _instance;
        private readonly List<Node> _referencedInstances;
    
        private static readonly Dictionary<object, Node> _Nodes = new Dictionary<object, Node>();
    
        public static Node CreateGraph(object instance)
        {
            ...
        }
        private static IEnumerable<object> FindReferencesOf(object instance)
        {
            ...
        }
    }
