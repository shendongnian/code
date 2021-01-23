    public class GenericLists<T>
    {
        private Dictionary<Type, List<T>> MyDict = new Dictionary<Type, List<T>>();
    
        public void NewEntry()
        {
            MyDict.Add(typeof(T), new List<T>());
        }
    
        public List<T> GetEntry()
        {
            return MyDict[typeof(T)];
        }
    
        public void RemoveEntry()
        {
            MyDict.Remove(typeof(T));
        }
    }
