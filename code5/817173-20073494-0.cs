    class ConcreteModem : IModem
    {
        public IModem Dial(string number)
        {
            if (connection is successful)
            {
                return new ConcreteModemDataExchange(); //whatever that is
            }
    
            return null;
        }
    }
