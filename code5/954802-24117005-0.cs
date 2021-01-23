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
    
    IEnumerable<Slot> slots = Enumerable.Repeat(0,401)
    									.Select(i => new Slot());
