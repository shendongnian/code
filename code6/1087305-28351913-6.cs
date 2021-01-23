      // We are going to use integer keys, with string values
      var stringGrades = new Dictionary<int, string>()
      {
        {1, "good"}, // 1 is the Key, "good" is the Value
        {2, "decent"},
        {3, "bad"}
      };
      int integerGrade;
      string textGrade;
        // try to convert the textbox text to an integer
      if(!Int32.TryParse(txtb_note.Text, out integerGrade) 
        // if successful, try to find the resulting integer 
        // (now in "integerGrade") among the keys of the dictionary
         || !stringGrades.TryGetValue(integerGrade, out textGrade))
         // Any of the above conditions weren't successful, so it's invalid
         lbl_ergebnis.Text = "Invalid value";
      else
         // It worked, so now we have our string value in the variable "textGrade"
         // obtained by the "out textGrade" parameter on TryGetValue
         lbl_ergebnis.Text = textGrade;
