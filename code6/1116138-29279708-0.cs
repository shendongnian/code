     foreach (var key in dictionary.Keys)
     {
        var tmp = string.Empty;
        foreach (var value in dictionary[key])
        {
           tmp +=value """";
           System.Console.WriteLine(tmp );
        }
     }
