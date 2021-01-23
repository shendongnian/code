    public class FirstLevelChild1 : TopLevelParent
    {
        protected override void TheAbstractMethod() { }
    }
    public class SecondLevelChild1 : FirstLevelChild1
    {
        protected override void TheAbstractMethod() { } // No problem
    }
    public class FirstLevelChild2 : TopLevelParent
    {
        protected sealed override void TheAbstractMethod() { }
    }
    public class SecondLevelChild : FirstLevelChild2
    {
        protected override void TheAbstractMethod() { } 
        // Error: cannot override inherited member 
        // 'FirstLevelChild2.TheAbstractMethod()' because it is sealed
    }
