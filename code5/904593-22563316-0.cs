    class Program
    {
        static void Main(string[] args)
        {
            var r1 = new Relation("name");
            var r2 = new Relation("name");
            HashSet<Relation> r = new HashSet<Relation>();
            r.Add(r1);
            bool test = r.Contains(r2);
        }
    }
    class Relation
    {
        public readonly string Name;
        public Relation(string name)
        {
            Name = name;
        }
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
        /// <see cref="System.Object.GetHashCode"/>
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
