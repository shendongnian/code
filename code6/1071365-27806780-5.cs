    class Foo
    {
        public string Seconds { get; set; }
	    public int OtherStuff { get; set; }
    }
    void Method2( object state )
    {
        var args = (Foo)state;			
        // use args.Seconds and args.OtherStuff here
    }
    // call this like so:
    var args = new Foo()
    {
        Seconds = "20",
        OtherStuff = 4711
    };
    ThreadPool.QueueUserWorkItem( Method2, args );
