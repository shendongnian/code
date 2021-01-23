    public class Actor
    {
        // equal objects must have equal hash codes
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    
        // objects with the same Id are equal
        public override bool Equals(object obj)
        {
            Actor other = obj as other;
            if (other == null)
                return false;
            return this.Id == other.Id;
        }
    
        [BsonId]
        public int Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("movies")]
        public List<Movies> Movies { get; set; }
    }
