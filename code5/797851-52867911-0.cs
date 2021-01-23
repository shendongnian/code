    public class Pair 
    { 
    	public int id {get;set;}
    	public string Arb {get;set;}
    }
    
    void Main()
    {
    	
    	var theList = new List<Pair>();
    	var randomiser = new Random();
    	for (int count = 1; count < 10000; count++)
    	{
    		theList.Add(new Pair 
    		{
    			id = randomiser.Next(1, 50),
    			Arb = "not used"
    		});
    	}
    	
    	var timer = new Stopwatch();
    	timer.Start();
    	var distinct = theList.GroupBy(c => c.id).Select(p => p.First().id);
    	timer.Stop();
    	Debug.WriteLine(timer.Elapsed);
    	
    	timer.Start();
    	var otherDistinct = theList.Select(p => p.id).Distinct();
    	timer.Stop();
    	Debug.WriteLine(timer.Elapsed);
    }
