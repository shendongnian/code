      string inValue="123.1"; //for example
      decimal number;
      bool result = Int32.TryParse(inValue, out number);
      if (result)
      {
         //The entered number is valid number (1 decimal)         
      }
      else
      {
         //bad input number.
         if (inValue == null) inValue = ""; 
         Console.WriteLine("Attempted conversion of '{0}' failed.", inValue);
      }
