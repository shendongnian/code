    public class NewDictionary
    {
        public Dictionary<Type, object> dic = new Dictionary<Type, object>();
        public void Add<T>(T obj)
        {
            dic[typeof(T)] = obj;
        }
        public T Get<T>()
        {
            if (IsTypeExists(typeof(T)) == false)
            {
                return default(T);
            }
            return (T)dic[typeof(T)];
        }
        public bool IsTypeExists(Type t)
        {
            if (dic.ContainsKey(t) == false)
                return false;
            else
                return true;
        }
    }
