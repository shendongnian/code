    [DataContract]
    public class MyValues
    {
       [DataMember]
       public string value1{get; set;}
       [DataMember]
       public string value2{get; set;}
       public override string ToString()
       {
          JavaScriptSerializer js = new JavaScriptSerializer(); // Available in   System.Web.Script.Serialization;           
          return js.Serialize(this);
       }
    }
