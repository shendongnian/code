    public class Dog {}
    public class Event {}
    
    public class Result {}
    
    // This is a linking table between Dog and Results
    public class DogResult
    {
        public int Id {get;set;}
        public int DogId {get;set;}
        public int ResultId {get;set;}
    }
    
    // This is a linking table between Events and Results
    public class EventResult
    {
        public int Id {get;set;}
        public int EventId {get;set;}
        public int ResultId {get;set;}
    }
