    var guid = Guid.NewGuid();
    Regex re = new Regex("[^a-fA-F0-9]");
    Console.WriteLine(guid.ToString());
    var stripped = re.Replace(guid.ToString(),"");
    Console.WriteLine(stripped);
    Guid newGuid;
    if (Guid.TryParse(stripped, out newGuid))
    {
    	Console.WriteLine(newGuid.ToString());
    }
    else
    {
    	Console.WriteLine("failed");
    }
