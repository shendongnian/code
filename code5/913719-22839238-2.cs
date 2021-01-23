    public class HumanFactory {
    	public T Create<T>() where T: Human, new() {
    		return new T();
    	}
    }
    public class Meeting<T> where T: Human {
        public T[] Visitors { get; set; }
    
        public Meeting(int number) {
    		var humanFactory = new HumanFactory();
    		Visitors = Enumerable.Range(1, number)
    		    .Select(x => humanFactory.Create<T>())
    		    .ToArray();
        }
    }
