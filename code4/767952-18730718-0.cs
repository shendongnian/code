    public static DateTime First() 
    {
        return GetByIndex(0);
    }
    public static DateTime Second() 
    {
        return GetByIndex(1);
    }
    public static DateTime GetByIndex(int index)
    {
        using (Entities db = new Entities())
           return db.Table.Select(a => a.TimeStamp).Skip(index).First();        
    }
