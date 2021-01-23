    [DataContract]
    public class EchoObj : WaveObj
    {
         [DataMember]
         public string Sound { get; set; }
         [DataMember]
         public string Volume { get; set; }
         [DataMember(EmitDefaultValue = false)]
         public DateTime TimeAt { get; set; }
         [DataMember]
         public override string Code
         {
             get { return "TestSound"; }
         }
         [DataMember]
         public override string Type
         {
             get { return "Test"; }
         }
    }
