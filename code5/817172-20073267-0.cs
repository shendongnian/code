    interface IModemConnection : IDisposable
    {
        void Dial(string number);
    }
    
    interface IModemDataExchange
    {
        void Send(char c);
        char Recv();
    }
    
    class ConcreteModemDataExchange : IModemDataExchange
    {
        ConcreteModemDataExchange(IModemDataExchange);
    }
