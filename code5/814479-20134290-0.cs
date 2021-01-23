    public interface BFactory {
    
       B Create(string bparam);
    
    }
    
    public class BFactoryUnity : BFactory {
       private IUnityContainer container;
    
       public BFactoryUnity(IUnityContainer container) {
         this.container = container;
       }
    
       public B Create(String bParam) {
           var b = new B(bParam);
           container.BuildUp(b);
           return b;
       }
    }
