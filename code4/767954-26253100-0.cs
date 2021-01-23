    public static DateTime GetByIndex(int index)
    {
        using (Entities db = new Entities()) {
           return db.Table.Select(a => a.TimeStamp).Skip(index).FirstOrDefault();        
        }
      return null;
    }
