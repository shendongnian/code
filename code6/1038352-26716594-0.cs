    public interface ID
    {
        int Id { get; }
    }
    public class IDImpl : ID
    {
        public int Id { get; private set; }
    }
    public static T GetById<T>(int id) where T : ID
    {
        var myDataContect db = new myDataContect();
        return (from u in db.GetTable<T> where u.Id == id select u).FirstOrDefault();
    } 
