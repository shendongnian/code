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
    IList<Slot> slotsList = Enumerable.Range(0,400)
                                  .Select(i => new Slot())
                                  .ToList();
    //or an enumerable
    IEnumerable<Slot> slots = slotsList;
   
    //or an array 
    Slot[] slotsArray = slotsList.ToArray();
