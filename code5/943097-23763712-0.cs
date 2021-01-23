    class Spam
    {
    	public void PrintFourNumbers(int a, int b, int c, int d)
    	{
    		Console.WriteLine(string.Join(" ", new string[] {a.ToString(), b.ToString(), c.ToString(), d.ToString()}));
    	}
    }
    
    class Beacon
    {
    	public System.Action<int, int, int, int> Bar(Spam instance)
    	{
    		return instance.PrintFourNumbers;
    	}
    }
    
    class Program
    {
    	public static void Main()
    	{
    		var b = new Beacon();
    		var s = new Spam();
    		b.Bar(s)(1, 2, 3, 4);
    	}
    }
    	
