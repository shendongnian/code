	void Main()
	{
		var slist = new List<Chunk>();
		var chunk = new Chunk{Name="asdf"};
		slist.Add(chunk);
		var slist2 = slist.ToList();
		slist[0].Name = "asdf2";
		Console.WriteLine(slist[0].Name); // outputs: asdf2
		Console.WriteLine(slist2[0].Name); // outputs: asdf2
	}
	
	public class Chunk
	{
		public string Name {get;set;}
	}
