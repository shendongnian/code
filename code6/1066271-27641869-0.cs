Single(l => l.GetType().GetProperty(prop).GetValue(l).ToString() == "Condition")
    void Main()
    {
	 var myList = Enumerable.Range(0,10).Select(i => new Xmas(i,"name"+i)).ToList();
	 string prop = "name";
	 Console.WriteLine(myList.Single(l => l.GetType().GetProperty(prop).GetValue(l).ToString() == "name6").name);
    }
    public class Xmas
    {
     public int id { get; set; }
     public string name { get; set; }
     public Xmas( int id, string name )
     {
      this.id = id;
      this.name = name;
     }
    }
