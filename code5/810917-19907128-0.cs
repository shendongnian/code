    var dic = new Dictionary<string, object>
    {
        {
            "key",
            string.Format("{0}", "hello") // this to avoid interning string
        }
    };
    Console.WriteLine(dic["key"] == "hello"); // false
    Console.WriteLine((string)dic["key"] == "hello"); // true
