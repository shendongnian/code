    public class Entity
    {
        public Entity()
        {
            RelationsTo = new List<Relation>();
            RelationsFrom = new List<Relation>();
        }
        public string Name { get; set; }
        public List<Relation> RelationsTo { get; private set; }
        public List<Relation> RelationsFrom { get; private set; }
    }
    public class RelationKind
    {
        public string Forwards { get; set; }
        public string Backwards { get; set; }
    }
    public class Relation
    {
        public RelationKind Kind { get; set; }
        public Entity From { get; set; }
        public Entity To { get; set; }
    }
