    public class MyObject 
    {
      private int _myInt;
      public int MyInt 
      {
        get { return _myInt; }
        set 
        { 
          _myInt = value; 
        }
        set(string) 
        { 
          _myInt = int.Parse(value); 
        }
      }
    }
