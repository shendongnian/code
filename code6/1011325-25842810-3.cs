    public class OuterClass {
       public OuterClass() {
          nestedClass = new NestedClass();
       }
    
       public int baseproperty { get; set; }
       public NestedClass nestedClass { get; set; }
    }
    
    public class NestedClass {
       public NestedClass() {
          deeper = new DeeperNestedClass();
       }
       public int NestedProperty { get; set; }
       public DeeperNestedClass deeper { get; set; }
    }
    
    public class DeeperNestedClass {
       public int VeryDeepPropery { get; set; }
    }
    
    class Program {
       static void Main(string[] args) {
          OuterClass outer = new OuterClass();
          int property = outer.nestedClass.deeper.VeryDeepPropery;
       }
    }
