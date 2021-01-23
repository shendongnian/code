    class ModelEqualityComparer : IEqualityComparer<Model>
    {
    
        public bool Equals(Model m1, Model m2)
        {
            if(m1 == null || 2. == null)
                return false;
            if (m1.Prop1 == m2.Prop1 
             && m1.Prop2 == m2.Prop2
             && m1.Prop3 == m2.Prop3
                ...
               )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    
    
        public int GetHashCode(Model m)
        {
            int hCode = m.Prop1.GetHashCode();
            hCode = hCode * 23 + ^ m.Prop2.GetHashCode();
            hCode = hCode * 23 + ^ m.Prop32.GetHashCode();
            ...
            return hCode;
        }
    
    }
