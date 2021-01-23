     delegate void EventHandler (SomeObject m, EventArgs e);
     EventHandler _priceChanged; //Private Delegate
     private Object _myLock = new Object();
        	
     public event EventHandler PriceChanged
     {
        add {
           lock(_myLock)
           {_priceChanged += value;}
        }
        remove {
           lock(_myLock)
           {_priceChanged -= value;} 
        }
     }
