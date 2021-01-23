    using System.Collections;
    void Main()
    {
	    var args = new Dictionary<string, string> {
		   {"Fruit1","Apple"}, 
		   {"Fruit2", "Orange"}, 
		   {"Greens", "Spinach"}
    	};
	
	    var output = Regex.Replace(
		 "Hi, my Fav fruits are {Fruit1} and {Fruit2}. I like {Papaya}", 
		 @"\{(\w+)\}", //replaces any text surrounded by { and }
		 m => 
			{
			    string value;
			    return args.TryGetValue(m.Groups[1].Value, out value) ? value : "null";
			}
	    );
	    Console.WriteLine(output);
    }
