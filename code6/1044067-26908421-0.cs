    public string SomeDateProperty
    {
       get { return _dateField.ToString('dd-MM-yyyy'); }
       set 
       { 
          if (value == '.') 
            value = DateTime.Today.ToString();
          _dateField = DateTime.Parse(value);
       }
    }
