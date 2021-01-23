    public class PersonRelation
    {
        // the pairing table must contain the key column, surrogated ID
        public virtual int Id { get; protected set; } // this is a must. 
    
        public virtual Person Parent { get; set; }
        public virtual Person Child { get; set; }
        public virtual string RelationType { get; set; }
    }
