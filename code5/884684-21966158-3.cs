    // override object.Equals
            public override bool Equals(object obj)
            {
               
                // checks for A versus A    
                if (obj == null || GetType() != obj.GetType())
                {
                    return false;
                }
    
                // TODO: write your implementation of Equals() here
                throw new NotImplementedException();
                int compareThis=(A)obj.x;
                return ((A)base).x==compareThis; // maybe casting is not needed
            }
