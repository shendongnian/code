    var resp = new HelloResponse();
    Console.WriteLine(resp.Pong); // "(nothing comes back!)"
    resp = new HelloResponse 
    {
        Pong = "Foobar";
    };
    Console.WriteLine(resp.Pong); // "Foobar"
