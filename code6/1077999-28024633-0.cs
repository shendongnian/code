    private IDictionary<int, string> _questionSetList;
    public IDictionary<int, string> QuestionSetList 
    { 
      get
      {
        if (_questionSetList == null)
        {
          _questionSetList = Dictionary<int, string>();
        }
        return _questionSetList;
      }
      set
      {
        _questionSetList = value;
      }
    }
