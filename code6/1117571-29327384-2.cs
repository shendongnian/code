    public string Country
    {
        get { return country; }
        set 
        {
            country = value;
            SetStatesForCountry( value );
            this.OnPropertyChanged();
        }
    }
    private IList<string> states;
    public IList<string> States
    {
      get{ return states; }
      private set { states = value; this.OnPropertyChanged(); } 
    }
    private void SetStatesForCountry( string selectedCountry )
    {
      IList<string> found;
      if( StatesPerCountry.Map.TryGetValue( selectedCountry, out found ) )
      {
        States = found;
      }
      else
      {
        States = null; //or you could set it to "not applicable" or so
      }
    }
