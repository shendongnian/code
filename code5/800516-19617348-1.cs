    public class SomeFellaWithAnEvent
    {
       public event EventHandler<MyEventArgs> OnMyEvent;
       private int _value;
       public int Value 
       { 
         get {return _value;} 
         set 
         {
           if (_value != value) 
           {
              _value = value;
              DoEvent(_value.ToString();
           }
         }
       }
       
       protected void DoEvent(String argData)
       {
          if (OnMyEvent != null)
          {
              OnMyEvent(this,new MyEventArgs(argData)) 
          }
       } 
    }
