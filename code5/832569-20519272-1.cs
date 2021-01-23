    public void UpdateDb<T>(int id) where T : IUpdateDbInterface
    {
        var UpdateTable = db.GetTable<T>()
                            .Where(p=> p.ID == id)
                            .FirstOrDefault();
        UpdateTable.IS_VALID = false;
        db.SaveChanges();
    }
    interface IUpdateDbInterface {
        int ID { get; set;}
        bool IS_VALID { get; set;}
    }
