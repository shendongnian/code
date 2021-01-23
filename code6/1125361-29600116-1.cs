    sealed class Airport
    {
        ...
        public override bool equals(Object obj)
        {
            return equals(obj as AirPort);
        }
        public bool equals(AirPort other)
        {
            if (other == null)
              return false;
            return other.id == id; //only id should be needed if unique
        }
        public override int GetHashCode()
        {
            return id.GetHashCode(); //again, only id needed
        }
    }
