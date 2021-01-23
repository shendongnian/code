        public class Object
        {
            public string Id { get; private set; }
            private readonly static Dictionary<string, Object> objectCollection = new Dictionary<string, Object>();
            public Object(string Id)
            {
                this.Id = Id;
                objectCollection.Add(Id, this);
            }
            public static Object Find(string id)
            {
                return objectCollection[id];
            }
        }
