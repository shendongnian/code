    public interface ISettableData
    {
        String Name { set; }
    }
    public interface IData : ISettableData
    {
        String Name { get; set; }
    }
