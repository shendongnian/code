    public abstract class Base
    {
        public int Id { get; set; }
    }
    public class Derived1 : Base
    {
        public int PropDerived1 { get; set; }
        public NavigationPropertyClass NavigationProperty { get; set; }
    }
    public class Derived2 : Base
    {
        public int PropDerived2 { get; set; }
        public int NavigationPropertyClassId { get; set; }
        public NavigationPropertyClass NavigationPropertyClass { get; set; }
    }
    public abstract class SomeOtherBaseClass
    {
        public int Id { get; set; }
    }
    public class NavigationPropertyClass : SomeOtherBaseClass
    {
        public Derived1 Derived1 { get; set; }
        public virtual ICollection<Derived2> Derived2s { get; set; }
    }
