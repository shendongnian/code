    foreach (var element in myArray) {
      double parsedDouble; int parsedInt;
      var defaultValue = element.ToString();
      if (Double.TryParse(defaultValue, out parsedDouble)) {
        // you have something that can be used as a double (the value is in "parsedDouble")
      } else if (Int32.TryParse(defaultValue, out parsedInt)){
        // you have something that can be used as an integer (the value is in "parsedInt")
      } else {
        // you have something that can be used as an string (the value is in "defaultValue")
      }
    }
