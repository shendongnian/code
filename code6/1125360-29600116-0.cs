    class Airport
    {
        ...
        public override bool equals(Object obj)
        {
            //types must be the exactly the same for non-sealed classes
            if (obj == null || obj.GetType() != GetType()) 
              return false;
            return equals((AirPort)obj);
        }
        private bool equals(AirPort other)
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
