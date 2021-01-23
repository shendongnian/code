    string value = "false";
    Boolean parsedValue;
    
    if (Boolean.TryParse(value, out parsedValue))
    {
          if (parsedValue)
          {
             // do stuff
          }
          else
          {
             // do other stuff
          }
    }
    else
    {
       // unable to parse
    }
