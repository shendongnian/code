    static void Main()
    {
        int i = new Random().Next();
        Console.WriteLine("> {0}", i);
        Guid guid = Guid.NewGuid();
        using (var muxer = ConnectionMultiplexer.Connect("127.0.0.1:6379"))
        {
            var db = muxer.GetDatabase();
            db.KeyDelete("foo");
            db.HashSet("foo", guid.ToByteArray(), i);
        }
        using (var muxer = ConnectionMultiplexer.Connect("127.0.0.1:6379"))
        {
            var db = muxer.GetDatabase();
            var val = (int)db.HashGet("foo", guid.ToByteArray());
            Console.WriteLine("< {0}", val);
        }
    }
