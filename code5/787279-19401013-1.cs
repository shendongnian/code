    public class MyClass{
        public MyClass(string file){
            // load a huge file
            // do lots of computing...
            // then store results...
        }
    }
    private ConcurrentDictionary<string,MyClass> Cache = new ....
    public MyClass GetCachedItem(string key){
        return Cache.GetOrAdd(key, k => new MyClass(key));
    }
