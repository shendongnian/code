    public static Client GetClientByID (int id)
    {
        var db = new DALEntities();
        return db.Client.SingleOrDefault(d => d.ClientID == id);
    }
