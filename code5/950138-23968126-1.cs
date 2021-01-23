    using (IModemConnection modemConnection = new IsdnModem())
    {
        IModemDataExchange dataExchange = modemConnection.Dial("123456")
        dataExchange.Send("Hello");
    }
