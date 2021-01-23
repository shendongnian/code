    public string rule(string playerId, string action, dynamic optionalData)
    {
    ...
                foreach (var pair in (IDictionary<string, object>)optionalData)
                {
                    if (group.Key == "url")
                    {
                       Console.WriteLine(group.Value);
                    }
                    else if (group.Key == "post")
                    {
                        Console.WriteLine(group.Value);
                    }
                }
     }
