    static void Main(string[] args)
    {
        while(true)
        {
            var beginTime = DateTime.Now;
            processData();
            var duration = DateTime.Now.Subtract( beginTime );
            // if you want to run 40 times per second,
            //  you need to spend 1000/40 = 25ms per iteration
            var sleepDuration = (int)(25 - duration.TotalMilliseconds);
            if( 0 < sleepDuration )
            {
                Thread.sleep(sleepDuration);
            }
        }
     }
