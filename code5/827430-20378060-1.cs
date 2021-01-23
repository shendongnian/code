[Datacontract(Namespace = "http://lorem")]
public class MyCustomData {
  [DataMember(Order = 0)]
  public int Dummy { get; set; } // had to define, otherwise I get invalid wire-type exception
  [DataMember(Order = 1)]
  public Guid Id { get; set; } // now ok
  [DataMember(Order = 2)]
  public int MyInt { get; set; } // serializes/deserializes ok
}
