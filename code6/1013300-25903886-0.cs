    void Main()
    {
    	int x = 0, y = 1, z = 2;
    	
    	var list = new List<int> { x, y, z };
    	list.ForEach(i => Console.WriteLine(i));
    	
    	x = y = z = 0;
    	list.ForEach(i => Console.WriteLine(i));
    	
    	WorseInt a = new WorseInt { Value = 0 },
    		b = new WorseInt { Value = 1 },
    		c = new WorseInt { Value = 2 };
    		
    	var worseList = new List<WorseInt> { a, b, c };
    	worseList.ForEach(i => Console.WriteLine(i.Value));
    	
    	a.Value = b.Value = c.Value = 0;
    	worseList.ForEach(i => Console.WriteLine(i.Value));
    }
    
    public class WorseInt
    {
    	public int Value { get; set; }
    }
