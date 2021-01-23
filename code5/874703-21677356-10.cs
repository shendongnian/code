    public class Actor : IEquatable<Actor>
    {
        public string ActorName;
        public string ActorRole;
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Actor);
        }
        public bool Equals(Actor other)
        {
            if ( other == null )
            {
                return false;
            }
            if ( object.ReferenceEquals(this, other) )
                return true;
            if ( !string.Equals(this.ActorName, other.ActorName) )
                return false;
            if ( !string.Equals(this.ActorRole, other.ActorRole) )
                return false;
            return true;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash     = hash * 31 + ((ActorName == null) ? 0 : ActorName.GetHashCode());
                hash     = hash * 31 + ((ActorRole == null) ? 0 : ActorRole.GetHashCode());
                return hash;
            }
        }
    }
    public class MovieArt : IEquatable<MovieArt>
    {
        public string ImagePath;
        public override bool Equals(object obj)
        {
            return this.Equals(obj as MovieArt);
        }
        public bool Equals(MovieArt other)
        {
            if ( other == null )
            {
                return false;
            }
            if ( object.ReferenceEquals(this, other) )
                return true;
            if ( !string.Equals(this.ImagePath, other.ImagePath) )
                return false;
            return true;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash     = hash * 31 + ((ImagePath == null) ? 0 : ImagePath.GetHashCode());
                return hash;
            }
        }
    }
