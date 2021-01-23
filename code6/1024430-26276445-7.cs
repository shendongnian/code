    interface IHierarchical<in T> 
    {
        T Parent
        {
            get; // ERROR
            set; // OK -- it's going in
        }
    }
