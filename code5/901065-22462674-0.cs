    public class A
    {
        public virtual void chop()
        {
        }
    }
    
    public abstract class D: A
    {
        public override void chop(){
           print("b.chop");
        }   
    }
    
    public class B: D
    {
       // other members specific to B
    }
    
    public class C: D
    {   
       // other members specific to C
    }
