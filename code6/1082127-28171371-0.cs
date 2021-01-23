    public static class B
    {
        public static void DoSomeJob()
        {
            // To do some job, I need to bind to A.SampleEvent
            A.SampleEvent += A_SampleEvent;
            // do job
        }
    
        private static void A_SampleEvent(object sender, EventArgs args)
        {
            // update B
            A.SampleEvent -= A_SampleEvent;
        }
    
        //other members of B ...
    }
