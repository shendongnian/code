    class MyModelTheUniqueIDComparer : IEqualityComparer<MyModel>
    {
        public bool Equals(MyModel x, MyModel y)
        {
            return x.SomeValue == y.SomeValue && x.OtherValue == y.OtherValue;
        }
    
        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.
    
        public int GetHashCode(MyModel myModel)
        {
            return myModel.SomeValue.GetHashCode() ^ myModel.OtherValue.GetHashCode();
        }
    }
