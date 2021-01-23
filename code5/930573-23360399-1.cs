    public enum Status
    {
         Okay,
         Wrong,
         SomethingElse
    };
    class WorkerResult 
    {
        public Status Status {get;set;}
        public object Data {get;set;}
    }
