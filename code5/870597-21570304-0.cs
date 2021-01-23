    public interface IRestrictedNoAandB {
      int c { get; set; }
      int d { get; set; }
    } 
    public interface IRestrictedNoA: IRestrictedNoAandB {
      int b { get; set; }
    } 
    
    public class test: IRestrictedNoA {
      public int a { get; set; }
      public int b { get; set; }
      public int c { get; set; }
      public int d { get; set; }
    }
    
    // You can't access property "a" within "call1" method
    void call1(IRestrictedNoA obj ) {...}
    // You can't access properties "a" and "b" within "call2" method
    void call2(IRestrictedNoAandB obj ) {...}
