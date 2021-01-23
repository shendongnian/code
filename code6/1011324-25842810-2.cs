    public class BaseClass {
       public NestedClass nestedClass { get; set; }
    
       public BaseClass() {
          nestedClass = new NestedClass();
       }
    
       public int baseproperty { get; set; }
    
       public class NestedClass {
          public int NestedProperty { get; set; }
       }
    }
    
    public class Derived : BaseClass {
       public Derived() {
          nestedClass = new NestedClass();
       }
       public class NestedClass : BaseClass.NestedClass {
          public DeeperNestedClass deeper { get; set; }
    
          public NestedClass() {
             deeper = new DeeperNestedClass();
          }
    
          public class DeeperNestedClass {
             public int VeryDeepPropery { get; set; }
          }
       }
    }
    
    class Program {
       static void Main(string[] args) {
          Derived derived = new Derived();
          BaseClass.NestedClass nestedBase = derived.nestedClass;
          Derived.NestedClass nestedDerived = (Derived.NestedClass)nestedBase;
          Derived.NestedClass.DeeperNestedClass deeper = nestedDerived.deeper;
          int property = deeper.VeryDeepPropery;
       }
    }
