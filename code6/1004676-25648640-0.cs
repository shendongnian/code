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
        public virtual ICollection<NavigationPropertyClass> NavigationPropertyClasses { get; set; }
    }
    public class NavigationPropertyClass
    {
        [ForeignKey("Derived1")]
        public int Id { get; set; }
        public Derived1 Derived1 { get; set; }
        public int Derived2Id { get; set; }
        public Derived2 Derived2 { get; set; }
    }
