        public class Object
        {
            public string Id { get; set; }
        }
        
        public class ObjectCollection<T> where T : Object
        { 
            private readonly static Dictionary<string, T> objectCollection = new Dictionary<string, T>();
            public void Add(T newObject)
            {
                objectCollection.Add(newObject.Id, newObject);
            }
            public static Object Find(string id)
            {
                return objectCollection[id];
            }
        }
