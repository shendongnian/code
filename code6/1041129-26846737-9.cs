    var rawMessages = new byte[][] {
        Encoding.ASCII.GetBytes("This\ni"),
        Encoding.ASCII.GetBytes("s\na"),
        Encoding.ASCII.GetBytes("\ntest!\n")
    };
    
    var arrayStream = new Subject<byte[]>();
    
    var messages =
        arrayStream.Select(bytes => bytes.ToObservable()).Concat()
                   .Publish(ps => ps.Where(p => p != 10)
                                    .Buffer(() => ps.Where(p => p == 10)))
                   .Select(ls => Encoding.ASCII.GetString(ls.ToArray())); 
    
    messages.Subscribe(b => Console.WriteLine(b));
    
    foreach(var array in rawMessages)
    {
        arrayStream.OnNext(array);
    }    
