    class Class2: Form {
        private object mylock = new object();
        private Output_args lastoutput = new Output_args();
        public void newOutput(object sender, Output_args args) {
            lock (mylock) {
                lastoutput = args.Copy();
            }
        }
    
        public void processor(){
            lock (mylock) {
                if (lastoutput.entrytime + 10000000 > System.DateTime.Now.Ticks) {
                // do something
                 }
            }
        }
    }
