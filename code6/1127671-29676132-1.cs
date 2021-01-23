    public class UserRepository<T> : Repository<T> where T: User, new()
    {
       public void Load()
       {
          User us = new T() as User;
          us.Code = "Cod";
          us.Language = "IT";
          _lst.Add(us);
       }
     }
