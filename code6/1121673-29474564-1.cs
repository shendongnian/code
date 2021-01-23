    using (var sr = new StringReader(json))
    using (var jr = new JsonTextReader(sr))
    {
        var js = new JsonSerializer();
        var u = js.Deserialize<classname>(jr);
        Console.WriteLine(u.Username );
    }
