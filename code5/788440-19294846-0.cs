    [Serializable]
    public class MyObject : ISerializable 
    {
      public int n1;
      public int n2;
      public String str;
    
      public MyObject()
      {
      }
    
      protected MyObject(SerializationInfo info, StreamingContext context)
      {
        n1 = info.GetInt32("i");
        n2 = info.GetInt32("j");
        str = info.GetString("k");
      }
    [SecurityPermissionAttribute(SecurityAction.Demand, 
    SerializationFormatter =true)]
    
    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
      {
        info.AddValue("i", n1);
        info.AddValue("j", n2);
        info.AddValue("k", str);
      }
    }
