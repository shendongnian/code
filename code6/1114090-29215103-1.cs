    public class ParentSchedule
    {
        protected readonly int[] numbersArray;
	    protected ParentSchedule(int[] numbersArray) {
	        this.numbersArray = numbersArray;
	    }
    }
    // Then the child class will be like the following:
    
    public class ChildSchedule: ParentSchedule
    {
        public ChildSchedule() : base(new int[24])
        {
        }
    }
