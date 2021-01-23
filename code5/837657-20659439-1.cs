    private Nullable<DateTime> myDateTimeProperty = null;
    public Nullable<DateTime> MyDateTimeProperty {
        get {
            if(myDateTimeProperty == null) {
                myDateTimeProperty = DateTime.Today;
            }
            return myDateTimeProperty;
        }
        set {
            myDateTimeProperty = value;
            RaisePropertyChangedEvent("MyDateTimeProperty");
        }
    }
