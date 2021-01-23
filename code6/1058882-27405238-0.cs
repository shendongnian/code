    var messages = new ConcurrentBag<string>();
    Parallel.ForEach(Arguments, Argument =>
    {
       ... 
       messages.Add(Argument + " => " + response.ReadToEnd());
    }
    var result = string.Join(Environment.NewLine, messages);
