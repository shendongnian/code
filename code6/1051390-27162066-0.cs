    using System;
    using System.Runtime.Serialization;
    
    [DataContract]
    public class YourDataModel
    {
        public YourDataModel() { }
    
        // When a property in your model doesn't 
        // match up exactly you can manually 
        // specify the name
        [DataMember(Name = "Column1")]
        public String Col1 { get; set; }
    
        // If things match up exactly (including case)
        // you don't need to manually map the Name
        [DataMember]
        public String Column2 { get; set; }
    }
