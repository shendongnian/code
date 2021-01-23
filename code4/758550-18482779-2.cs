    public class SomeHandler: IHandleMessages<object>, ISpecifyMessageHandlerOrdering
    {
        public IBus Bus {get;set;}
        public void Handle(object message)
        {
            Bus.DoNotContinueDispatchingCurrentMessageToHandlers();
        }
        public void SpecifyOrder(Order order)
        {
            order.SpecifyFirst<SomeHandler>();
        }
    }
