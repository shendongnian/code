    public interface IA {
       void Test();
    }
    //implicitly implement
    public class A : IA {
       public void Test() { ... }
    }
    var a = new A();
    a.Test();//you can do this
    
    //explicitly implement
    public class A : IA {
       void IA.Test() { ... } //note that there is no public and the interface name 
                              // is required
    }
    var a = new A();
    ((IA)a).Test(); //this is how you do it.
