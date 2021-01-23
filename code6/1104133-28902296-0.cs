        public override int GetHashCode()
        {
            return this.EqualityIdentifier.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            IDomainObject Obj = obj as IDomainObject 
            if (Obj == null)
            {
                return false;
            }
            return this.EqualityIdentifier == Obj.EqualityIdentifier;
        }
