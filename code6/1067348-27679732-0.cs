    public class BaseDAL
    {
        public BaseDAL(int ID)
        {
           this.id= ID;
        }
        
        int id;
        protected object GetOrder()
        {
            using (var DB = AccessManager.db)
            {
                return DB.Videos.Where(x => x.ID == id).SingleOrDefault();
            }
        }
    
        public object GetByID()
        {
            using (var DB = AccessManager.db)
            {
                return DB.Videos.Where(x => x.ID == id).SingleOrDefault();
            }
        }
    }
