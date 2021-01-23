    class Worker
    {
        public string Seconds { get; set; }
        public int OtherStuff { get; set; }
        public void DoWork( object unused )
        {
            // use this.Seconds and this.OtherStuff here
        }
    }
    // call like so:
    var worker = new Worker()
    {
        Seconds = "20",
        OtherStuff = 4711
    };
    ThreadPool.QueueUserWorkItem( worker.DoWork );
