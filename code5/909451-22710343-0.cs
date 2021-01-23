    interface IMessageShowingStrategy 
    {
        void ShowMessage(...)
    }
    
    class RealMessageShowingStrategy : IMessageShowingStrategy 
    {
        void ShowMessage(...) 
        {
            // Real code
        }
    }
    
    class TestingMessageShowingStrategy : IMessageShowingStrategy
    {
        void ShowMessage(...)
        {
            // Code used for testing
        }
    }
    class Message 
    {
        IMessageShowingStrategy messageStrategy;
    
        void ShowMessage(...)
        {
            this.messageStrategy.ShowMessage(...);
        }
    
    }
