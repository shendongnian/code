    public class HumanFactory {
    	public Human Create(Gender gender) {
    		return gender == Gender.Male ? (Human)new Man(number) : (Human)new Woman(number);
    	}
    }
    public class Meeting {
        private Human[] visitors;
        public Human[] Visitors { get { return visitors; } set { visitors = value; } }
    
        public Meeting(Gender gender, int number) {
    		visitors = new Human[number];
    		
    		var factory = new HumanFactory();
    		for (int i = 0; i < number; i++) {
    			visitors[i] = humanFactory.Create(gender);
    		}
    		// Shorter:
    		// visitors = Enumerable.Range(1, number)
    		//     .Select(x => humanFactory.Create(gender))
    		//     .ToArray();
        }
    }
