    var parsedJson = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, dynamic>>>(json);
    foreach (var element in parsedJson)
    {
    	Console.WriteLine(element.Key);
    	foreach (var item in element.Value)
    	{
    		Console.WriteLine(item.Key);
    		Console.WriteLine(item.Value.Description);
    		Console.WriteLine(item.Value.OutcomeDateTime);
    		IEnumerable<dynamic> competitors = item.Value.Competitors.Competitors;
    		Console.WriteLine(string.Join(",", competitors.Select(x => x.Team)));
    
    	}
    }
