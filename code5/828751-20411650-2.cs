    class Master
    {
        List<Slave> Slaves { get; set; }
    }
    class Slave
    {
        Master Master { get; set; }
    }
