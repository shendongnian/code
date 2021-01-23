    public class MySubClass : MyBaseClass
    {
        // ...
        
        public int SomeValue { get; set; }
        
        public override int CompareTo(MyBaseClass other)
        {
            if (other == null) {
                return 1;
            }
            
            var typedOther = other as MyBaseClass;
            if (typedOther != null) {
                return this.SomeValue.CompareTo(typedOther.SomeValue);
            } else {
                return GetType().FullName.CompareTo(other.GetType().FullName);
            }
        }
    }
