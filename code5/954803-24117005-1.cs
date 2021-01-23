    public class Slot
    {
    	private Gene[] _genes;
    
    	public Gene this[int index]
    	{
    		get{ return _genes[index];}
    		set{ _genes[index] = value;}
    	}
    
    	public Slot(int count = 100)
    	{
    		_genes = new Gene[count];
    	}
    }
    
    IEnumerable<Slot> slots = Enumerable.Range(0,400)
    									.Select(i => new Slot());
    //or a list
    IList<Slot> slotsList = slots.ToList();
   
    //or an array 
    Slot[] slotsArray = slots.ToArray();
