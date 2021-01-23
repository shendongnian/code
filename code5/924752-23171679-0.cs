    private double cLeft;
    public double CLeft
    {
       get
       {
          return cLeft;
       }
       set
       {
          if(cLeft != value)
          {
             cLeft = value;
             OnPropertyChanged("CLeft");
          }
       }
    }
