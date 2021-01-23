    public static Dog Get(string dogname, MyDataContext db)
    {
        var result = db.Dogs.SingleOrDefault(d => d.name == dogname);
        return result;
    }
