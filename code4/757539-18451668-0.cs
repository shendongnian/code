    public static class GenericLists
    {
        private static Dictionary<Type, object> MyDict = new Dictionary<Type, object>();
        public static void NewEntry<T>()
        {
            MyDict.Add(typeof(T), new List<T>());
        }
    
        public static List<T> GetEntry<T>()
        {
            return (List<T>)MyDict[typeof(T)];
        }
    
        public static void RemoveEntry<T>()
        {
            MyDict.Remove(typeof(T));
        }
    
    }
