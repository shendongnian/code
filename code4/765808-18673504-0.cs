        public override bool Equals(object obj)
        {
            var other = obj as ClientLookup;
            if (other == null)
                return false;
            return Id.Equals(other.Id);
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        public override string ToString()
        {
            return Id.ToString();
        }
