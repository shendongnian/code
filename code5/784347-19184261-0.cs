    class MyModelTheUniqueIDComparer : IEqualityComparer<MyModel>
    {
        public bool Equals(MyModel x, MyModel y)
        {
            return x.TheUniqueID == y.TheUniqueID;
        }
    
        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.
    
        public int GetHashCode(MyModel myModel)
        {
            return myModel.TheUniqueID.GetHashCode();
        }
    }
