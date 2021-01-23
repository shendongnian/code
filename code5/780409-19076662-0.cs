    public class SuperObject : IDisposable {
        public void Dispose() {
            // Dispose code...just call dispose on dispoable members.
        }
    }
    
    public interface ICustom : IDisposable { }
    public class Custom : ICustom {
        public SuperObject Super { get; protected set; }
    
        public Custom() {
            Super = new SuperObject();
        }
    
        public void Dispose() {
            if (Super != null)
                Super.Dispose();
        }
    }  
    
    public class Moo : Controller {
        Custom c;
    
        public Moo() {
            c = new Custom();
        }
    
        public Dispose() {
            if (c!=null)
                c.Dispose()
            base.Dispose();       
        }
    }
