    public interface IBouncer {
         IEnumerable<IFooConsumer> WhoIsInside {get;}
         void WelcomeTo(IFooConsumer consumer);
         void EscortOut(IFooConsumer consumer);
    }
    public Consumer: IFooConsumer {
        public Consumer(IBouncer bouncer) {
            bouncer.WelcomeTo(this);
        }
        
        public Dispose() {
            bouncer.EscortOut(this); // dispose pattern ommitted
        }
    }
