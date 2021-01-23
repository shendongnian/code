    class Example
    {
        Example(IUnityContainter container) 
        {
            _receiveQueue = container.Resolve<IQueue>("ReceiveQueue");
            _sendQueue = container.Resolve<IQueue>("SendQueue");
        }
    }
