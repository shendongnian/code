    public class BaseDAL
    {
        public CurrentIndex { get; set; }
        public Order GetOrder()
        {
            using (var DB = AccessManager.db) {
                return DB.Videos.Where(x => x.ID == CurrentIndex).SingleOrDefault();
            }
        }
        ...
    }
