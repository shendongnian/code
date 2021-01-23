    public class PersonFilterModel
    { 
        public int Page //the one from your example
        public string Name {get;set;}
        public int? age {get;set;}
        public int? id {get;set;}
        //you can add properties for filter type (starts with, less than, bigger than)
    }
