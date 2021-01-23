    private DateTime? _startDate;
    public DateTime startDate {
      get {
        if (!_startDate.HasValue) {
          string[] ymd = Environment.GetCommandLineArgs()[2].Split('.');
          _startDate = new DateTime(Int32.Parse(ymd[2]), Int32.Parse(ymd[1]), Int32.Parse(ymd[0]));
        }
        return _startDate.Value;
      }
      set { _startDate = value; }
    }
