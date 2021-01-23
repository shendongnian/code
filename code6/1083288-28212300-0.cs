    public interface IStationProperty
    {
      int Id { get; set; }
      string Desc { get; set; } 
      Type ValueType { get; }
    }
    public interface IStationProperty<T> : IStationProperty
    { 
       T Value { get; } 
    }
