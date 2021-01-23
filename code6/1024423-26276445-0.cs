    interface IHierarchical<out T>
    {
        T Parent
        {
            get; // OK -- it's going out.
            set; // ERROR
        }
    }
