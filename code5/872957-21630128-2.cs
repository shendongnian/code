    public sealed class Bob
    {
        private Alice _alice;
        public void DoJob()
        {
            //Have Alice produce the report
            var reportTask = _alice.ProduceReport();
            //Talk around the water cooler...
            //Okay, the report is due, so Bob waits by his desk for Alice to hand it over
            //If Alice was already done, she may have just left it on his desk
            var report = reportTask.Result;
            //Do something with the report...
        }
    }
    public sealed class Alice
    {
        public async Task DoOtherStuff()
        {
            //Other stuff requested by other folks, broken up similarly into small chunks using await...
        }
        public async Task<Report> ProduceReport()
        {
            //Alice sets the task to run
            //She lets the caller (Bob) know that she's started, so he can continue with his work
            await Task.Run((Action)CrunchNumbers);
            //Alice gets the text message, then finishes up the report
            //She goes and hands it to Bob at his desk
            return new Report();
        }
        private void CrunchNumbers()
        {
            //Crunch, crunch...
        }
    }
