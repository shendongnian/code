    class CableComparer : IEqualityComparer<Cable>
    {
    
        public bool Equals(Cable c1, Cable c2)//these represent any two cables.
        {
            if (c1.Height == c2.Height && ...)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    
    
        public int GetHashCode(Cable c)
        {
            //this will work if each ID is unique
            return c.Id.GetHashCode();
            //otherwise you do this:
            //return (c.Id ^ c. CablePropertyId).GetHashCode();
        }
    }
