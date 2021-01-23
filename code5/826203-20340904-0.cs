    private bool CurrentlyValidated
    {
      get
      {
        return DateTime.Now < _expiryTime && _validated ;
      }
      set
      {
        _validated  = value ;
        _expiryTime = DateTime.Now.AddMinutes(5) ;
      }
    }
    private bool     _validated  ;
    private DateTime _expiryTime ;
  
