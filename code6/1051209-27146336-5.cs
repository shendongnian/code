    public class MovieActorAssociation
    {
        public MovieActorAssociation(Actor actor, Movie movie)
        {
            Actor = actor;
            Movie = movie;
        }
        protected MovieActorAssociation()
        {
        }
        public virtual Actor Actor { get; protected set; }
        public virtual int Id { get; protected set; }
        public virtual Movie Movie { get; protected set; }
        public virtual string SomeOtherProperty { get; set; }
        public static bool operator ==(MovieActorAssociation left, MovieActorAssociation right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(MovieActorAssociation left, MovieActorAssociation right)
        {
            return !Equals(left, right);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != GetType())
            {
                return false;
            }
            return Equals((MovieActorAssociation)obj);
        }
        public override int GetHashCode()
        {
            return Id;
        }
        protected bool Equals(MovieActorAssociation other)
        {
            return Id == other.Id;
        }
    }
