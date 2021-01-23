    string result = string.Empty;
    
    foreach (var item in jobj)
    {
        if (!string.IsNullOrEmpty(result))
        {
            result += ",";
        }
        result += item.Key;
    }
    Console.WriteLine(result);
