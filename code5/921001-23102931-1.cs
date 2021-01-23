    public FDObjectBase(SerializationInfo info, StreamingContext context) : this()
    {
        int version = Generics.GetSerializedValue<int>(info, "Version");
        if (version >= 1)
        {
            Left = (double)info.GetValue("Left", typeof(double));
            Top = (double)info.GetValue("Top", typeof(double));
            Height = (double)info.GetValue("Height", typeof(double));
            Width = (double)info.GetValue("Width", typeof(double));
            DesignObjectID = (int)info.GetValue("DesignObjectID", typeof(int));
            ShapeType = (int)info.GetValue("ShapeType", typeof(int));
            Angle = (double)info.GetValue("Angle", typeof(double));
            ObjectType = ((int)info.GetValue("ObjectType", typeof(int))).GetEnumValue<ObjectType>();
        }
        if (version >= 2)
        {
            //Add newly added properties for this version
        }
        else { 
            //Add default values for new properties for this version
        }
        OnDeserialized(new EventArgs());
    } 
