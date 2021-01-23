      // This time, we directly use string as keys
      var stringGrades = new Dictionary<string, string>()
      {
        {"1", "good"},
        {"2", "decent"},
        {"3", "bad"}
      };
      string textGrade;
      // Try to get the value in the dictionary for the key matching the text
      // on your textbox, no need to convert to integer
      if(!stringGrades.TryGetValue(txtb_note.Text, out textGrade))
         lbl_ergebnis.Text = "Invalid value";
      else
         lbl_ergebnis.Text = textGrade;
