    private Visibility _mockVisibility;
    public Visibility MockVisibility
    {
       get
       {
          return _mockVisibility;
       }
       set
       {
           Debug.WriteLine("MockVisibility called with " + value);
           _mockVisibility = value;
       }
    }
