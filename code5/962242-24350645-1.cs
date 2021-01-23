        class Tag<T>{
    
        }
        class ClassMap {
            private Dictionary<object, object> map = new Dictionary<object,object>();
    
            public void put<T>(Tag<T> tag, T value){
                map.Add(tag, value);
            }
    
            public T get<T>(Tag<T> tag){
                return (T)map[tag];
            }
        }
        public class Program
        {
            public static void Main(string[] args)
            {
                ClassMap v = new ClassMap();
                Tag<Int16> t = new Tag<short>();
                v.put<short>(t, 10);
                var tt = v.get<short>(t);
            }
        }
