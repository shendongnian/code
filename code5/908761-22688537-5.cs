    public class MySubClass : MyBaseClass
    {
        // ...
        
        public int SomeValue { get; set; }
        
        public override int CompareTo(MyBaseClass other)
        {
            if (other == null) {
                // every instance comes after null, cf. docs
                return 1;
            }
            
            var typedOther = other as MyBaseClass;
            if (typedOther != null) {
                // other instance of same type; compare by custom sorting criteria
                return this.SomeValue.CompareTo(typedOther.SomeValue);
            } else {
                // other instance of different type; make sure different types are always sorted in the same order
                return GetType().FullName.CompareTo(other.GetType().FullName);
            }
        }
    }
