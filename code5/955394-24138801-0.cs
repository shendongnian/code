    public abstract class ChainElem
    {
    	public abstract bool IsMatching(object o);
    	public abstract void Do(object o);
    }
    	
    public class ChainElemIList : ChainElem{
    	public override bool IsMatching(object o) {
    		//Matches IList implementations only.
    		if( o is IList )
    			return true; 
    		else
    			return false;
    	}
    	
    	public override void Do(object o) {
    		//Do something with the IList
    		Console.WriteLine("processing IList...");
    	}
    }
    
    public class ChainElemIEnumerable : ChainElem{
    	public override bool IsMatching(object o) {
    		//Matches all IEnumerable implementations(but not string).
    		//This is something that you won't achieve with generics.
    		if( o is IEnumerable && !(o is string) )
    			return true; 
    		else
    			return false;
    	}
    	
    	public override void Do(object o) {
    		//Do something with the IEnumerable(but not string)
    		Console.WriteLine("processing IEnumerable(but not string)...");
    	}
    }
    
    public class ChainElemString : ChainElem{
    	public override bool IsMatching(object o) {
    		//Matches strings only.
    		if( o is string )
    			return true; 
    		else
    			return false;
    	}
    	
    	public override void Do(object o) {
    		//Do something with the string
    		Console.WriteLine("processing string...");
    	}
    }
    
    public class ChainElemObject : ChainElem{
    	public override bool IsMatching(object o) {
    		//Matches everything else.	
    		return true; 
    	}
    	
    	public override void Do(object o) {
    		//Do something with the object
    		Console.WriteLine("processing object...");
    	}
    }
    
    void Main()
    {
        string s = "TEST";
        List<string> list = new List<string> {s};
        Stack<string> stack = new Stack<string>();
        stack.Push( s );
    	object o = new object();
    
    	//construct the chain - order is important and depends on your requirements
        var chain = new List<ChainElem> {
    		new ChainElemIList(),
    		new ChainElemIEnumerable(),
    		new ChainElemString(),
    		new ChainElemObject()
    	};
    	
    	//processing
    	chain.First(c => c.IsMatching(list)).Do(list);
    	chain.First(c => c.IsMatching(stack)).Do(stack);
    	chain.First(c => c.IsMatching(s)).Do(s);
    	chain.First(c => c.IsMatching(o)).Do(o);
    	
    	//OUTPUT:
    	//	processing IList...
    	//	processing IEnumerable(but not string)...
    	//	processing string...
    	//	processing object...
    
    }
