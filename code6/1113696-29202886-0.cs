    public class Program
    {
    	public static void Main()
    	{
    		var list = new  List<Sample>();
    		list.Add(new SampleDerived(){ Age=2, DAge = 5 });
    		list.Add(new SampleDerived(){ Age=3, DAge = 5 });
    		list.Add(new SampleDerived(){ Age=4, DAge = 5 });
    		list.Add(new SampleDerived(){ Age=5, DAge = 5 });
    		list.Add(new SampleDerived(){ Age=6, DAge = 5 });
    		var list2 = list.ToArray();
    		Process(ref list2[2]);
    		Console.WriteLine(list2[2].Age); // will print 10 not 4
    	}
    	
    	public static void Process(ref Sample s)
    	{
    		s = new Sample(){Age=10};
    	}
    }
    public class Sample
    {
    	public int Age {get; set;}
    }
    
    public class SampleDerived : Sample
    {
    	public int DAge {get; set;}
    }
