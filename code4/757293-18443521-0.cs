    class ItemEqualityComparer : IEqualityComparer<Item>
    {
    
        public bool Equals(Item i1, Item i2) 
        {
            if (i1.ID == i2.ID && i1.Name == i2.Name && 
               (i1.DrugCode1 == i2.DrugCode1 || i1.DrugCode1 == i2.DrugCode2 ||    
                i1.DrugCode2 == i2.DrugCode1 ))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    
    // maybe you need to implement the GetHashCode method too!
    
    }
