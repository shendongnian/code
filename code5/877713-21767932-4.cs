    public void SetDataType(string type)
    {
        try
        {
            SetDataType(type != null ? typeof (Type) : typeof (string));
        }
