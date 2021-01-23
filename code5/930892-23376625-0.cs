     // it is only infrastructure if it doesn't know about specific types directly
        public Repository<T>
        {
           public T Find(int id)
           {
               // resolve the entity
               return default(T);   
           }
        }
