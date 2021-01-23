    class myModel
    {
       public event EventHandler OnNameChanged = delegate { };
    
       private _name;
       public string name 
       { 
          get { return _name; } 
          set 
          {
             _name = value;
        
             if (OnNameChanged != null)
                OnNameChanged(this, new NameChangedEventArgs(value))
          } 
       }
    }
    
    public class NameChangedEventArgs : EventArgs
    {
       private _name;
    
       public NameChangedEventArgs(string name) { _name = name; }
       public Name { get { return _name; } }
    }
