    // you can figure out a better name this just for example
    interface ICommon
    {
        int Id { get; set; }
    }
    public static T getById<T>(int Id) where T : ICommon
    {
        myDataContect db = new myDataContect();
        return (from u in db.GetTable<T> where u.Id == Id select u).FirstOrDefault();
    }
