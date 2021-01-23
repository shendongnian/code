    interface IFoo {
        int Size {get;}
    }
    // This class already does what you need, but does not implement
    // your interface of interest
    class OldClass {
        int Size {get;private set;}
        public OldClass(int size) { Size = size; }
    }
    // Derive from the existing class, and implement the interface
    class NewClass : OldClass, IFoo {
        public NewCLass(int size) : base(size) {}
    }
