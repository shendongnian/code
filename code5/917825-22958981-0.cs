      [DataContract]
      public class reviewList
      {
         [DataMember]
       public List<review> reviewListArray{ get; set; }
      }
     [DataContract]
     public class review
     {
       [DataMember]
       public string item { get; set; }
       [DataMember]
       public string suggestion { get; set; }
       [DataMember]
       public List<Ratting> rating{ get; set; }
      }
      [DataContract]
      public class Ratting
      {
       [DataMember]
       public int label{ get; set; }
       [DataMember]
       public int value{ get; set; }
      }
