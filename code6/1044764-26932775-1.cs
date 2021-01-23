    class myModel
    {
       public event EventHandler OnNameChanged(object sender, NameChangedEventArgs e); = delegate { };
    
       private _name;
       public string Name 
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
