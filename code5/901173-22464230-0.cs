    public static class TFactory 
    { 
        public static T Getmplementation<T>()
        {            
            var typeName = typeof(T).Name;
            var type = Type.GetType(typeName);
            if (type != null)
                return Activator.CreateInstance(type) as T;
            else
                throw new NotImplementedException(typeName);
        }
    }
