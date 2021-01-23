    // override object.Equals
            public override bool Equals(object obj)
            {
               
    
                if (obj == null || GetType() != obj.GetType())
                {
                    return false;
                }
    
                // TODO: write your implementation of Equals() here
                throw new NotImplementedException();
                return base.Equals(obj);
            }
