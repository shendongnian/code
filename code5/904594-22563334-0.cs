    internal class Relation
    {
        public string Name { get; set; }
        public override bool Equals(object obj)
        {
            bool equals = false;
            if (obj is Relation)
            {
                Relation relation = (Relation)obj;
                equals = Name.Equals(relation.Name);
            }
            return equals;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var relation1 = new Relation() {Name = "Bob"};
            var relation2 = new Relation {Name = "Bob"};
            var relations = new HashSet<Relation>();
            relations.Add(relation1);
            var does = relations.Contains(relation2);
            // does is now true
        }
    }
