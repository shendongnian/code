    internal class Node
    {
        internal string Id { get; set; }
        internal IEnumerable<Node> Children { get; set; } 
        internal bool IsEmergency { get; set; }
    
        internal bool IsEmergencyHierarchy
        {
            get { return IsEmergency || 
                         (Children != null && Children.Any(n => n.IsEmergencyHierarchy)); }
        }
    }
