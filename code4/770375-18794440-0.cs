    public static void ToSerializedObjectForDebugging(this object o, FileInfo saveTo)
    {
        Type t = o.GetType();
        XmlSerializer s = new XmlSerializer(t);
        using (FileStream fs = saveTo.Create())
        {
            s.Serialize(fs, o);
        }
    }
