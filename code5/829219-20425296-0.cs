    class Params
    {
        public int Start { get; set; }
        public int End { get; set; }
        public int[] Array { get; set; }
    }
    
    var p = new Params { 0, 0, new int[0] };
    var t = new Thread(thr2.Thread2);
    t.Start(p);
    public int Thread2(object param)
    {
        var p = (Params)param;
        // and now get your arguments as p.Start etc.
    }
