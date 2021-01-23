	public static void Main()
	{
       string str = "aaaaaaaaaabcccccc";
        var qry = (from c in str
                   group c by c into grp
				   let c = grp.Count()
                   select grp.Key.ToString() + (c > 1 ? c.ToString() : ""));
		
		Console.WriteLine(string.Join("",qry));
        Console.ReadLine();
	}
