    public interface ICreateTime
    {
        DateTime CreateTime { get; }
    }
    public DateTime TimeOf(ICreateTime myObject)
    {
        return myObject.CreateTime;
    }
    
