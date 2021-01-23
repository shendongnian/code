    public abstract class Entity
    {
        public virtual long Id { get; protected set; }
        
        public override bool Equals(object obj)
        {
            var other = obj as Entity;
            return other != null && (Id == 0 ? ReferenceEquals(this, other) : Id == other.Id);
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
