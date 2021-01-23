    var input = "a,  b,  c";
	Dictionary<string, string>  lookup = new Dictionary<string, string>()
	{
	    {"a", "1"},
	    {"b", "2"},
	    {"c", "3"}
	};
	string result = Regex.Replace(input, "[abc]", m => lookup[m.Value] , RegexOptions.None);
	Console.WriteLine(result); // outputs 1,  2,  3
