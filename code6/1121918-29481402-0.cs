    public class MyObject 
    {
      public int MyInt { get; set; }
    
      public void set_MyInt(string value)
      {
        MyInt = int.Parse(value);
      }
    }
