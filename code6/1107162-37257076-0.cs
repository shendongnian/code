    public static string Concat(string[] args)
    {
        return string.Concat(args);
    }
    var functions = new Dictionary<string, ParamsFunc<string, string>>();
    functions.Add("concat", Concat);
    var concat = functions["concat"];
    Console.WriteLine(concat());                                //Output: ""
    Console.WriteLine(concat("A"));                             //Output: "A"
    Console.WriteLine(concat("A", "B"));                        //Output: "AB"
    Console.WriteLine(concat(new string[] { "A", "B", "C" }));  //Output: "ABC"
