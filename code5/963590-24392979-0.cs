    public static List<division> GetAllDivisions(bool isAvailable)
    {
        MyDataContext db = new MyDataContext();
        return db.divisions
                 .Where(d => d.isAvailable == isAvailable)
                 .ToList();
    }
