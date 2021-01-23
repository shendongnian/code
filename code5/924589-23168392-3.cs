    private int _rate;
    public int Rate{
      set{
        if(_rate != value){
          _rate = value;
          // Call the callbacks passing an EventArgs that reflects the actual state
          //   of the product
          OnChanged(this, new ProductChangedEventArgs(_rate, ... ));
        }
      }
    }
