    public interface IMyGenericDBProcessor
    {
        void AddToDB<T>(T Record) where T : class;
    }
    public class MyDBProcessor : IMyGenericDBProcessor 
    {
        public void AddToDB<T>(T record) where T : class
        {
            using(var tp = new tpEntities())
                tp.Set<T>().Add(record);
        }
    }
