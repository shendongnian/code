    private string _keyword
    public string keyword
    {
      get
      { 
        return _keyword;
      }
      set
      {
        _keyword=value;
        VoiceSearch();
      }
    }
