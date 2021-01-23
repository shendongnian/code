    public interface ISendQueue : IQueue {}
    public interface IReceiveQueue : IQueue {}
    class Example
    {
        Example(IReceiveQueue receiveQueue, ISendQueue sendQueue) {}
    }
    
