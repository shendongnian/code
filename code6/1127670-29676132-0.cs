    public class UserRepository<T> : Repository<T> where T: AbsObj, new()
    {
       public void Load()
       {
          IAbsObj us = new T() as IAbsObj;
          us.Code = "Cod";
          us.Language = "IT";
          _lst.Add(us);
       }
     }
