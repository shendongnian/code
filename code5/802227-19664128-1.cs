    public class MyClass : List<int> 
    {
        public int this[string key] {
    		get {
    			return this.Where(x=>x==int.Parse(key)).SingleOrDefault();
    		}
    	}
    }
