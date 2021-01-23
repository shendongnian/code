    string input="key=muchdata1&key=muchdata2&keys=muchdata3";
    var data=input.Split(new[] { "&" }, StringSplitOptions.None);
    List<String> keyValues = new List<String>();
    foreach(string d in data)
    {
        if(d.StartsWith("key="))
        {
            keyValues.Add(d.Substring(4));
        }
    }
    //Access Values Here
    foreach (string d in keyValues)
    {
        Console.WriteLine(d);
    }
    Console.ReadKey();;
