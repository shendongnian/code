    class BusinessEqualityComparer : IEqualityComparer<Business>
    {
    
        public bool Equals(Business b1, Business b2)
        {
            if (b1.ID == b2.ID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    
    
        public int GetHashCode(Business business)
        {
            int hCode = business.ID ^ business.ID ^ business.ID;
            return hCode.GetHashCode();
        }
