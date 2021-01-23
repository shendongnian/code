    public class NewRepo : IDataRepository<UserBusiness>
    {
        YourContext db = new YourContext();
        public IQueryable<UserBusiness> Get()
        {
            return (from u in db.UserDAL select new UserBusiness()
            {
               Id = u.Id,
               Name = u.Name
            });
        }
        public UserBusiness Get(int id)
        {
            return (from u in db.UserDAL where u.Id == id select new UserBusiness()
            {
               Id = u.Id,
               Name = u.Name
            }).FirstOrDefault();
        }
 
        public Order Add(UserBusiness obj)
        {
            UserDAL u= new UserDAL();
            u.Name = obj.Name;
            db.UserDAL.Add(u);
            db.SaveChanges();
            //Assuming the database is generating your Id's for you
            obj.Id = u.Id;
            return obj;
        }
        public Order Update(UserBusiness obj)
        {
            UserDAL u= new UserDAL();
            u.Id = obj.Id;
            u.Name = obj.Name;
            db.Entry(u).State = EntityState.Modified;
            db.SaveChanges();
            return obj;
        }
        public void Delete(UserBusiness obj)
        {
            UserDAL u = db.UserDAL.Where(o=>o.Id == obj.Id);
            if (u!=Null)  {
              db.Entry(u).State = EntityState.Deleted;
              db.SaveChanges();
            }
        }
    }
