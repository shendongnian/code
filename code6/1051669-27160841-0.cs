    var source = "10000100010";
    
    // convert to stream of char
    var cs = source.ToCharArray().ToObservable();
    
    var res = cs.Publish(ps => ps.Where(c => c != '1')
                                 .Buffer(() => ps.Where(c => c == '1')))
                .Select(c => c.Count).Max().Wait();
                
    Console.WriteLine(res);    
