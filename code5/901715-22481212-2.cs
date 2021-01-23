    public BusinessLayer.Session GetSession ()
    {
        //...
        return (BusinessLayer.Session)ser.ReadObject(dataStream);
    }
