    //...JToken token
    if (token.Type == JTokenType.Array)
    {
        IEnumerable<Phone> phones = token.ToObject<List<Phone>>();
    }
    else if (token.Type == JTokenType.Object)
    {
        Phone phone = token.ToObject<Phone>();
    }
    else
    {
        Console.WriteLine($"Neither, it's actually a {token.Type}");
    }
