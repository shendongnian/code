    class ValueHolder {
	    public int tag;
	    public int blah;
	    public int otherBlah;
	    public ValueHolder(int t, int b, int o)
        { tag = t; blah = b; otherBlah = o; }
    };
    static ValueHolder findHolderWithTag(List<ValueHolder> buffer, int tag) {
	    // find holder with tag i
	    foreach (var holder in buffer) {
		    if (holder.tag == tag)
			    return holder;
	    }
        return new ValueHolder(0, 0, 0);
    }
    static void Main(string[] args)
    {
	    const int MAX = 99999;
	    int  count = 1000; // _wtoi(argv[1]);
        List<ValueHolder> vs = new List<ValueHolder>();
	    for (int i = MAX; i >= 0; i--) {
		    vs.Add(new ValueHolder(i, 0, 0)); // construct valueholder with tag i, blahs of 0
	    }
	    var watch = new Stopwatch();
        watch.Start();
	    for (int i = 0; i < count; i++)
	    {
		    ValueHolder found = findHolderWithTag(vs, i);
            if (found.tag != i)
                throw new ArgumentException("not found");
	    }
        watch.Stop();
        TimeSpan ts = watch.Elapsed;
        Console.WriteLine("Hours: {0} Miniutes: {1} Seconds: {2} Milliseconds: {3}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
    }
