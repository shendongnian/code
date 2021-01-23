    public abstract class foo {
    
       public virtual void bar(){..}
    }
    
    public class footwo : foo {
       public override void bar(){
           // do somethng else OR:
           return base.bar();
       }
    }
   
}
