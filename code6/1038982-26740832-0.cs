    using System;
    using System.Runtime.Serialization;
    [Serializable]
    [DataContract]
    public class Model
    {
        [DataMember(Name = "value")]
        public string value { get; set; }
        [DataMember(Name = "title")]    
        public string title { get; set; }
    }
    [Serializable]
    [DataContract]
    public class VehicleMake
    {
        [DataMember(Name = "value")]
        public string value { get; set; }
   
        [DataMember(Name = "title")]
        public string title { get; set; }
        [DataMember(Name = "models")]
        public List<Model> models { get; set; }
    }
