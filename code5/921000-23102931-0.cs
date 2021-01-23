    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("Version", VERSION_NUMBER);
        //First Version properties
        info.AddValue("Left", Left);
        info.AddValue("Top", Top);
        info.AddValue("Height", Height);
        info.AddValue("Width", Width);
        info.AddValue("DesignObjectID", DesignObjectID);
        info.AddValue("ShapeType", ShapeType);
        info.AddValue("ObjectType", ObjectType.GetIntValue());
        info.AddValue("Angle", Angle);
        //Second Version Properties
    }
