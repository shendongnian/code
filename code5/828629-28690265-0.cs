        using JTC.Framework.Json;
        ...
        public class People
        {
            // other attributes removed for demonstration simplicity
        
            public List<Person> People { get;set; }
        }
        
        public abstract class Person
        {
              [JsonProperty()]
              public string Id {get;set;}
              [JsonProperty()]
              public string Name {get;set;}
        }
        
        public class Employee : Person 
        {
              public string Badge {get;set;}
        }
        
        public class Customer : Person
        {
             public string VendorCategory {get;set;}
        }
