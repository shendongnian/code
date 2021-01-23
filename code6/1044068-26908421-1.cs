    // disclaimer: untested pseudo-code
    private DateTime? _dateTimeField;
    public string SomeDateProperty
    {
       get { return _dateTimeField.ToString('dd-MM-yyyy'); }
       set 
       { 
          if (value == '.') 
            value = DateTime.Today.ToString();
          _dateTimeField = DateTime.Parse(value);
       }
    }
