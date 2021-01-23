    class Example<T>
    {
        Collection<T> collection = new Collection<T>(); 
        public void AddSomeClassIntoCollection(T item)
        {
            collection.Add(item);
        }
    }
