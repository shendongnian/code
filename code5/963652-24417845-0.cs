    static IObservable<string> Messages(IObservable<char> source)
    {
        var pub = source.Publish().RefCount();
        return pub
            .Buffer(pub.Where(char.IsLetter))
            .Select(buffer => new string(buffer.ToArray()));
    }
