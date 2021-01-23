    private double buttonTop;
    public double ButtonTop
    {
       get { return buttonTop; }
       set
       {
          if(buttonTop != value)
          {
             // Synchronize here
             buttonTop = value;
          }
       }
    }
