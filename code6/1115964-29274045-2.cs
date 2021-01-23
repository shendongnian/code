    public class BaseRepo {
    }
    public class MainRepository<T> : BaseRepo where T : BaseRepo{
        public List<T> GetAll(){
            return new List<T>();
        }
    }
