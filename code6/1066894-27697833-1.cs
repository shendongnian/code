    // a serilaizable class
    // Make this as you like
    [Serializable]
    public class MyClass
    {
    
       public byte[] SomeArbitaryBytes { get; set; }
       public string SomeArbitaryString { get; set; }
       public int SomeArbitaryInt { get; set; }
       public double SomeArbitaryDouble { get; set; }
    
       public MyClass()
       {
    
          SomeArbitaryString = "hello";
          SomeArbitaryInt = 7;
          SomeArbitaryDouble = 98.1;
          SomeArbitaryBytes = new byte[10];
          for (var i = 0; i < SomeArbitaryBytes.Length; i++)
          {
             SomeArbitaryBytes[i] = (byte)i;
          }
       }
    }
