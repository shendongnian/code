    protected Device(SerializationInfo info, StreamingContext context)
    {
        Name = info.GetString("Name");
        //...
        AssociatedMibEntity = (MibEntity)info.GetValue(
            "AssociatedMibEntity", typeof(MibEntity)); 
    }
    void ISerializable.GetObjectData(
        SerializationInfo info, StreamingContext context)
    {
        info.AddValue("Name", Name);
        //...
        info.AddValue("AssociatedMibEntity", AssociatedMibEntity);
    }
