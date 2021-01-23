    public class Customer {
       private string _myproperty = String.Empty;
       public string myproperty 
       { 
          get { return _myproperty; }; 
          set { _myproperty = value ?? String.Empty; } 
       }
    }
