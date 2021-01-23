    public interface IBouncer {
         IEnumerable<IFooConsumer> WhoIsInside {get;}
         void WelcomeTo(IFooConsumer consumer);
         void EscortOut(IFooConsumer consumer);
    }
    public Consumer: IFooConsumer {
        public Consumer(IBouncer lounge) {
            lounge.WelcomeTo(this);
        }
        
        public Dispose() {
            lounge.EscortOut(this); // dispose pattern ommitted
        }
    }
