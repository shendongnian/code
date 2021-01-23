    public DerivedClass(object SomeParam = null) : base(SomeParam) {
      customSecondaryProp = 10;
      someValue = 5;
      if (SomeParam != null) { 
        when = DateTime.Now;
      }
    }
    public MyBaseClass(object SomeParam) {
      someValue = 1;
      preserveParam = SomeParam;
    }
