    private Bool cbSecial = false;
    private Bool cb1 = false;
    private Bool cb2 = false;
    public Bool CbSpecial 
    {
       get { return cbSecial; }
       set 
       {
          if (value == cbSecial) return;
          cbSecial = value;
          if (cbSpecial) 
          {
              Cb1 = false;
              Cb2 = false;
              ... 
          }
          NotifyPropertyChanged("CbSpecial");
       }
    }
    public Bool Cb1 
    {
       get { return cb1; }
       set 
       {
          if (value == cb1) return;
          cb1 = value;
          NotifyPropertyChanged("Cb1 ");
       }
    }
          
