    public class HumanFactory {
    	public Human Create(Gender gender) {
    		return gender == Gender.Male ? (Human)new Man(number) : (Human)new Woman(number);
    	}
    }
    public class Meeting {
        public Human[] Visitors { get; set; }
    
        public Meeting(Gender gender, int number) {
    		Visitors = Enumerable.Range(1, number)
    		    .Select(x => humanFactory.Create(gender))
    		    .ToArray();
        }
    }
