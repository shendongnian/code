    public class Entity
    {
        public List<Relationship> RelationsTo { get; }
        public List<Relationship> RelationsFrom { get; }
    }
    public class RelationshipKind
    {
        public string Forwards { get; set; }
        public string Backwards { get; set; }
    }
    public class Relationship
    {
        RelationshipKind Kind { get; set; }
        public Entity From { get; set; }
        public Entity To { get; set; }
    }
